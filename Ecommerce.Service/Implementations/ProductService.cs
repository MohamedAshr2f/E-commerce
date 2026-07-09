using Ecommerce.Data.Entities.Product;
using Ecommerce.Infrastructure.InfrastructureBases;
using Ecommerce.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Implementations
{
    public class ProductService : IProductService
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(IUnitOfWork unitOfWork, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetTableNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .AsSplitQuery()
                .ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetSortedProductsAsync(string? sortBy, int? CategoryId)
        {
            var query = _unitOfWork.ProductRepository.GetTableNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .AsSplitQuery().AsQueryable();
            if (CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == CategoryId);
            }

            query = sortBy?.ToLower() switch
            {
                "name" => query.OrderBy(p => p.Name),
                "name_desc" => query.OrderByDescending(p => p.Name),
                "price" => query.OrderBy(p => p.NewPrice),
                "price_desc" => query.OrderByDescending(p => p.NewPrice),
                "rating" => query.OrderBy(p => p.Rating),
                "rating_desc" => query.OrderByDescending(p => p.Rating),
                "newest" => query.OrderByDescending(p => p.Id),
                _ => query.OrderBy(p => p.Id)
            };

            return await query.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetTableNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .AsSplitQuery()
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> GetProductByIdWithoutIncludeAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<string> AddProductAsync(Product product, IFormFileCollection images)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            // var imageUrl = await _fileService.UploadImage("Products", images);
            await _unitOfWork.ProductRepository.AddAsync(product);

            if (images != null && images.Count > 0)
            {
                var uploadedImages = await _fileService.UploadImage("Products", images, product.Name);

                if (uploadedImages.Count > 0 && uploadedImages[0] != "FailedToUploadImage")
                {
                    var ImageUrl = baseUrl + uploadedImages[0];
                    foreach (var imagePath in uploadedImages)
                    {
                        var photo = new Photo
                        {
                            ImageName = imagePath,
                            ProductId = product.Id
                        };
                        await _unitOfWork.PhotoRepository.AddAsync(photo);
                    }

                }
                else
                {
                    return "Failed to upload images.";
                }
            }
            return "Product added successfully.";
        }

        public async Task<string> DeleteProductImagesAsync(Product product)
        {
            var photos = await _unitOfWork.PhotoRepository.GetTableNoTracking()
                .Where(p => p.ProductId == product.Id)
                .ToListAsync();
            foreach (var photo in photos)
            {
                var result = await _fileService.DeleteImage("Products", photo.ImageName, product.Name);
                if (result == "FailedForDeleteImage")
                {
                    return "FailedToDeleteImages";
                }
                await _unitOfWork.PhotoRepository.DeleteAsync(photo);
            }

            return "ImagesDeletedSuccessfully";
        }

        public async Task<string> UpdateProductAsync(Product product, IFormFileCollection images)
        {

            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            await _unitOfWork.ProductRepository.UpdateAsync(product);

            if (images != null && images.Count > 0)
            {

                var uploadedImages = await _fileService.UploadImage("Products", images, product.Name);

                if (uploadedImages.Count > 0 && uploadedImages[0] != "FailedToUploadImage")
                {
                    var ImageUrl = baseUrl + uploadedImages[0];
                    foreach (var imagePath in uploadedImages)
                    {
                        var photo = new Photo
                        {
                            ImageName = imagePath,
                            ProductId = product.Id
                        };
                        await _unitOfWork.PhotoRepository.AddAsync(photo);
                    }
                }
                else
                {

                    return "FailedToUploadImage";
                }
            }
            return "Product updated successfully.";

        }

        public async Task<string> DeleteProductAsync(Product product)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(product);
            return "Deleted";
        }


    }
}

