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
        /// <summary>
        /// returns null if not succeeded
        /// return urls if succeeded
        /// </summary>
        /// <param name="uploadUrl">path</param>
        /// <param name="files">files</param>
        public string[] WriteFile(string uploadUrl = "upload", params IFormFile[] files)
        {
            string[] savedImageUrls = new string[files.Length];
            string fileName;

            for (int i = 0; i < files.Length; i++)
            {
                fileName = Guid.NewGuid() + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + Path.GetExtension(files[i].FileName);
                var path = Path.Combine($@"wwwroot\{uploadUrl}", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                    files[i].CopyTo(stream);

                savedImageUrls[i] = fileName;
            }

            return savedImageUrls;
        }

        /// <summary>
        /// returns null if succeeded
        /// return urls if not succeeded
        /// </summary>
        /// <param name="urls"></param>
        public string[] DeleteFile(params string[] urls)
        {
            string[] notDeletedImageUrls = Array.Empty<string>();
            int index = 0;
            for (int i = 0; i < urls.Length; i++)
            {
                if (File.Exists($@"wwwroot\{urls[i]}"))
                {
                    File.Delete($@"wwwroot\{urls[i]}");
                }
                else
                {
                    //yield return urls[i];
                    Array.Resize(ref notDeletedImageUrls, index + 1);
                    notDeletedImageUrls[index] = urls[i];
                    index++;
                }
            }

            return notDeletedImageUrls;
        }
    }
}
