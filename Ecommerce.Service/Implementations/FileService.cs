using Ecommerce.Data.Helpers;
using Ecommerce.Service.Abstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace Ecommerce.Service.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> IsValidImageFileExtension(IFormFile file)
        {
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);
                var isAllowed = FileSettings.AllowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                {
                    return false;
                }
            }
            return true;

        }

        public async Task<bool> IsValidImageFileMaxLength(IFormFile file)
        {

            if (file is not null)
            {
                if (file.Length > FileSettings.MaxFileSizeInBytes)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<List<string>> UploadImage(string Location, IFormFileCollection file)
        {
            List<string> result = new List<string>();
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var item in file)
                {
                    if (item.Length > 0)
                    {
                        var extension = Path.GetExtension(item.FileName);
                        var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;
                        var fullPath = Path.Combine(path, fileName);
                        using (FileStream filestream = File.Create(fullPath))
                        {
                            await item.CopyToAsync(filestream);
                            await filestream.FlushAsync();

                        }
                        result.Add($"/{Location}/{fileName}");
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<string> { "FailedToUploadImage" };
            }
        }
        public void DeleteImage(string Location, string fileName)
        {
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/";
            var fullPath = Path.Combine(path, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

        }


    }
}
