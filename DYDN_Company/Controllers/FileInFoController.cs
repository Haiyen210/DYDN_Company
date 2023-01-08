using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using DYDN_Company.Models;
using static System.Net.Mime.MediaTypeNames;
using DYDN_Company.Services;
using System.Threading;

namespace DYDN_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddCors")]
    public class FileInFoController : ControllerBase
    {
        private readonly FileService _fileService;

        public FileInFoController(FileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok ");
        }



        // download file(s) to client according path: rootDirectory/subDirectory with single zip file
        [HttpGet("Download/{subDirectory}")]
        public IActionResult DownloadFiles(string subDirectory)
        {
            try
            {
                var (fileType, archiveData, archiveName) = _fileService.FetechFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }



 

        // upload file(s) to server that palce under path: rootDirectory/subDirectory
        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm(Name = "file")] List<IFormFile> files, string subDirectory)
        {
            try
            {
                //Thread.Sleep(10000);
                _fileService.SaveFile(files, subDirectory);
                return Ok(new { files.Count, Size = FileService.SizeConverter(files.Sum(f => f.Length))});
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }
    }


}