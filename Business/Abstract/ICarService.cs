
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IDataResult<List<Car>> GetAllCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetAllCarsByColorId(int colorId);
        IDataResult<Car> GetCarById(int carId);
        IDataResult<List<CarDetailsDto>> GetAllCarsWithDetails();
        IDataResult<List<Car>> GetAllCarsBetweenMinAndMax(int min, int max);
        IDataResult<List<Car>> GetAllCarsIfExist();
        IDataResult<List<Car>> GetAllCarsIfExist(bool control);
        IResult DeleteById(int carId);
        IDataResult<CarDetailsDto> GetCarWithDetailById(int carId);
        IResult Update(Car car);
    }
}
