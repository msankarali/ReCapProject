using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BrandGetListWithCarsDto
    {
        public string BrandName { get; set; }
        public List<BrandGetListWithCarsDto_CarItem> CarList { get; set; } = new List<BrandGetListWithCarsDto_CarItem>();
    }

    public class BrandGetListWithCarsDto_CarItem
    {
        public string CarName { get; set; }
        public short ModelYear { get; set; }
    }
}
