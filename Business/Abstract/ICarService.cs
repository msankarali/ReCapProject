﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IResult Add(Car car);

        IDataResult<List<CarDetailsDto>> GetAllCarsByBrandId(int brandId);

        IDataResult<List<CarDetailsDto>> GetAllCarsByColorId(int colorId);

        IDataResult<Car> GetCarById(int carId);

        IDataResult<List<CarDetailsDto>> GetAllCarsWithDetails(CarFilterDto carFilterDto);

        IDataResult<List<Car>> GetAllCarsBetweenMinAndMax(int min, int max);

        IDataResult<List<Car>> GetAllCarsIfExist();

        IDataResult<List<Car>> GetAllCarsIfExist(bool control);

        IResult DeleteById(int carId);

        IDataResult<CarDetailsWithImagesDto> GetCarWithDetailsByCarId(int carId);

        IResult Update(Car car);

        IDataResult<List<Car>> GetAllCarsIfNotRented();

    }
}