
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        List<Car> GetAllCarsByBrandId(int brandId);
        List<Car> GetAllCarsByColorId(int colorId);
        Car GetCarById(int carId);
        List<CarDetailsDto> GetAllCarsWithDetails();
        List<Car> GetAllCarsBetweenMinAndMax(int min, int max);
        List<Car> GetAllCarsIfExist();
        List<Car> GetAllCarsIfExist(bool control);
        void DeleteById(int carId);
        CarDetailsDto GetCarWithDetailById(int carId);
        void Update(Car car);
    }
}
