using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetAllCarsWithDetails(int? brandId, int? colorId);

        CarDetailsDto GetCarWithDetailById(int carId);
    }
}