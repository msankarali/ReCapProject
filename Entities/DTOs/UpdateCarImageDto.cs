using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UpdateCarImageDto : IDto
    {
        public int CarImageId { get; set; }
        public IFormFile CarImage { get; set; }
    }
}
