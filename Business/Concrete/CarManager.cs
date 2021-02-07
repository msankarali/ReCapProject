using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0) _carDal.Add(car);
            else Console.WriteLine("Araba ismi minimum 2 karakter olmalı ve günlük ücreti sıfırdan büyük olmalı");
        }

        public void CheckId(Car car)
        {
            if (car.CarId == 0) _carDal.Add(car);
            else _carDal.Update(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllCarsBetweenMinAndMax(int min, int max)
        {
            return _carDal.GetAll(c => c.DailyPrice < max && c.DailyPrice > min);
        }

        public List<Car> GetAllCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetAllCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetAllCarsIfExist()
        {
            return _carDal.GetAll(c => c.IsActive == true);
        }

        public List<CarDetailsDto> GetAllCarsWithDetails()
        {
            return _carDal.GetAllCarsWithDetails();
        }

        public Car GetCarById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }
    }
}
