using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _carList;

        public InMemoryCarDal()
        {
            _carList = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 90, ModelYear = 2001, Description = "Fiat Palio"},
                new Car{CarId = 2, BrandId = 2, ColorId = 2, DailyPrice = 400, ModelYear = 2020, Description = "Skoda Octavia"},
                new Car{CarId = 3, BrandId = 2, ColorId = 3, DailyPrice = 500, ModelYear = 2020, Description = "Skoda SUPERB"},
                new Car{CarId = 4, BrandId = 3, ColorId = 4, DailyPrice = 250, ModelYear = 2018, Description = "Fiat Doblo"},
                new Car{CarId = 5, BrandId = 3, ColorId = 4, DailyPrice = 150, ModelYear = 2014, Description = "Dacia Duster"}
            };
        }

        public void Add(Car car)
        {
            car.CarId = _carList.Count + 1;
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = GetById(car.CarId);
            _carList.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carList.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetAllCarsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _carList.SingleOrDefault(cl => cl.CarId == id);
        }

        public CarDetailsDto GetCarWithDetailById(int carId)
        {
            throw new NotImplementedException();
        }

        public Car GetLast(Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = GetById(car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}