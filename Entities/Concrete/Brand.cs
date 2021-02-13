using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}