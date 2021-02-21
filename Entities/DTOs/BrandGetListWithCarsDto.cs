using Entities.Concrete;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class BrandGetListWithCarsDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<BrandGetListWithCarsDto_CarItem> CarList { get; set; } = new List<BrandGetListWithCarsDto_CarItem>();
    }

    public class BrandGetListWithCarsDto_CarItem
    {
        public string CarName { get; set; }
        public short ModelYear { get; set; }
    }
}
