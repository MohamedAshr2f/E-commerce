using Microsoft.AspNetCore.Http;

namespace Ecommerce.Service.Abstracts
{
    public interface IFileService
    {
        public Task<bool> IsValidImageFileMaxLength(IFormFile file);
        public Task<bool> IsValidImageFileExtension(IFormFile file);
        public Task<List<string>> UploadImage(string Location, IFormFileCollection file, string productname);
        public Task<string> DeleteImage(string Location, string fileName, string name);
    }
}
