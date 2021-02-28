using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public interface IFileHelper
    {
        string[] WriteFile(string uploadUrl = "upload", params IFormFile[] file);
    }
}
