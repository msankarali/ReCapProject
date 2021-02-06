using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
            if (car.Description.Length > 2 && car.DailyPrice > 0) _carDal.Add(car);
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

        public List<Car> GetAllCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetAllCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
