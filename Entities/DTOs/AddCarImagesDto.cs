using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddCarImagesDto : IDto
    {
        public IFormFile[] CarImages { get; set; }
        public int CarId { get; set; }
    }
}
