using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace App.core.Helpers
{
    public static class FileUploaderHelper
    {
        public static string Upload(IFormFile file, string folderName, string filePath)
        {
            if (file == null || file.Length == 0)
                return "";

            string extension = Path.GetExtension(file.FileName);
            string physicalPath = Path.Combine(folderName, filePath);
            if (!Directory.Exists(physicalPath))
            {
                Directory.CreateDirectory(physicalPath);
            }

            var physicalFileName = $"{Guid.NewGuid()}_{file.Name}{extension}";

            using (var fileStream = new FileStream(Path.Combine(physicalPath, physicalFileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Path.Combine(physicalPath, physicalFileName);
        }

        public static string SaveImage(IFormFile file, string entityName, IHostingEnvironment host)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(host.WebRootPath, entityName);
                FileInfo fileInfo = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fileInfo.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }

        public static async Task ReadFileStreamAsync(string filePath, Func<Stream, Task> callBack)
        {
            using var fileStream = File.OpenRead(filePath);
            await callBack(fileStream);
        }

        public static async Task DownloadFile(Stream outputStream, Action<string, string> setResponseInfo, string filePath)
        {
            await ReadFileStreamAsync(filePath,
                async (Stream zipInputStream) =>
                {
                    await SendStreamToOutputAsync(outputStream, setResponseInfo, zipInputStream, Path.GetFileName(filePath));
                });
        }

        private static async Task SendStreamToOutputAsync(Stream outputStream, Action<string, string> setResponseInfo, Stream zipInputStream, string filename)
        {
            setResponseInfo.Invoke("application/octet-stream", filename);
            await zipInputStream.CopyToAsync(outputStream);
        }
    }
}
