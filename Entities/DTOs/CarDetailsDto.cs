using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public short ModelYear { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}