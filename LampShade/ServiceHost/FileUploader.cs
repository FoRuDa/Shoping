﻿using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using _0_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ServiceHost
{
    public class FileUploader:IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file,string path)
        {
            if (file == null) return "";

            var directoryPath= $"{_webHostEnvironment.WebRootPath}/ProductPicture/{path}";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileTime()}-{file.FileName}";
            var filePath = $"{directoryPath }/{fileName}";
            using var output = System.IO.File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
    }
}