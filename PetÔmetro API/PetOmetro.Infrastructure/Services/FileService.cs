using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PetOmetro.Application.Interfaces.Services;
using System;
using System.IO;

namespace PetOmetro.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private string _uploadFolder => "/uploads/";

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string UploadFile(IFormFile file, string[] extensios)
        {
            string filePath = string.Empty;

            if (file.Length > 0)
            {
                string partialPath = Guid.NewGuid().ToString();
                filePath = Path.Combine(_uploadFolder, partialPath + Path.GetExtension(file.FileName));

                var path = _hostingEnvironment.ContentRootPath + _uploadFolder;

                CreateDirectory(path);

                using (var fileStream = new FileStream(_hostingEnvironment.ContentRootPath + filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return filePath;
        }

        public byte[] GetFile(string path)
        {
            path = _hostingEnvironment.ContentRootPath + _uploadFolder + path;

            if (File.Exists(path))
                return File.ReadAllBytes(path);

            return null;
        }

        public void DeleteFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            path = _hostingEnvironment.ContentRootPath + path;

            if (File.Exists(path))
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                }
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
