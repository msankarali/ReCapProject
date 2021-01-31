using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : InMemoryBaseRepositoryDal<Car>
    {
        List<Car> _carList;
        public InMemoryCarDal()
        {
            _carList = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 90, ModelYear = 2001, Description = "Fiat Palio"},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 400, ModelYear = 2020, Description = "Skoda Octavia"},
                new Car{Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 500, ModelYear = 2020, Description = "Skoda SUPERB"},
                new Car{Id = 4, BrandId = 3, ColorId = 4, DailyPrice = 250, ModelYear = 2018, Description = "Fiat Doblo"},
                new Car{Id = 5, BrandId = 3, ColorId = 4, DailyPrice = 150, ModelYear = 2014, Description = "Dacia Duster"}
            };
        }
        public void Add(Car car)
        {
            car.Id = _carList.Count + 1;
            _carList.Add(car);
            Console.WriteLine(car.Description + " added.");
        }

        public void Delete(Car car)
        {
            Car carToDelete = GetById(car.Id);
            _carList.Remove(carToDelete);
        }


        public List<Car> GetAll()
        {
            return _carList.ToList();
        }

        public Car GetById(int id)
        {
            return _carList.SingleOrDefault(cl => cl.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = GetById(car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
