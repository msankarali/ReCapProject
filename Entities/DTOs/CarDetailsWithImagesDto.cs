using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailsWithImagesDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public short ModelYear { get; set; }
        public string Description { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
