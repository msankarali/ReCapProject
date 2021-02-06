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
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void CheckId(Car car)
        {
            if (car.CarId == 0)
            {
                _carDal.Add(car);
            }
            else
            {
                _carDal.Update(car);
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
