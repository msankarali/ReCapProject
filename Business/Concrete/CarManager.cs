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

        public string Add(Car car)
        {
            if (car.DailyPrice < 600)
            {
                _carDal.Add(car);
                return "Araba başarıyla eklendi!";
            }
            else
            {
                return "Arabanız ücret skalasını geçtiği için ekleyemezsiniz!";
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
