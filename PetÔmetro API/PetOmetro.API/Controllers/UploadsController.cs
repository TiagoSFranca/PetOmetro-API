using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.Interfaces.Services;
using System;

namespace PetOmetro.API.Controllers
{
    [ApiController]
    [Route("uploads")]
    public class UploadsController : Controller
    {
        private readonly IFileService _fileService;

        public UploadsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Byte[] b;
            b = _fileService.GetFile(id);

            return File(b, "image/jpeg");
        }
    }
}
