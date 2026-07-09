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

        public async Task<List<string>> UploadImage(string Location, IFormFileCollection file, string productname)
        {
            List<string> result = new List<string>();
            var name = productname.Replace(" ", "_");
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/" + name + "/";

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
                        result.Add($"/{Location}/{name}/{fileName}");
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<string> { "FailedToUploadImage" };
            }
        }
        public async Task<string> DeleteImage(string Location, string fileName, string productname)
        {
            var name = productname.Replace(" ", "_");
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/" + name + "/";
            var fullPath = Path.Combine(path, Path.GetFileName(fileName));

            try
            {

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return "Deleted";
                }
                return "NotFound";
            }
            catch (Exception)
            {
                return "FailedForDeleteImage";
            }

        }


    }
}
