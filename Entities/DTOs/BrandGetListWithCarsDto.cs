using Entities.Concrete;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class BrandGetListWithCarsDto
    {
        public string BrandName { get; set; }
        public List<Car> CarList { get; set; } = new List<Car>();
    }

    public class BrandGetListWithCarsDto_CarItem
    {
        public string CarName { get; set; }
        public short ModelYear { get; set; }
    }
}