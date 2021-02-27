using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string[] WriteFile(string uploadUrl = "upload", params IFormFile[] files)
        {
            string[] savedImageUrls = new string[files.Length];
            string fileName;

            for (int i = 0; i < files.Length; i++)
            {
                fileName = Guid.NewGuid() + Path.GetExtension(files[i].FileName);
                var path = Path.Combine($@"wwwroot\{uploadUrl}", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                    files[i].CopyTo(stream);

                savedImageUrls[i] = fileName;
            }

            return savedImageUrls;
        }
    }
}
