using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public string CarName { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Rental> Rentals { get; set; }
        public List<CarImage> CarImages { get; set; }
        //public int KurumId { get; set; }
        //public bool IsDeleted { get; set; } = false;
    }
}