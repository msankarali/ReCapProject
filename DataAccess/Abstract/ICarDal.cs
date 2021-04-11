using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetAllCarsWithDetails(CarFilterDto carFilterDto);

        CarDetailsWithImagesDto GetCarWithDetailById(int carId);
    }
}