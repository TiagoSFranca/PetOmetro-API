using Microsoft.AspNetCore.Http;

namespace PetOmetro.Application.Interfaces.Services
{
    public interface IFileService
    {
        string UploadFile(IFormFile file, string[] extensios);
        byte[] GetFile(string path);
        void DeleteFile(string path);
    }
}
