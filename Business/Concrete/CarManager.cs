using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult();
            }
            else return new ErrorResult("Araba eklerken bir sorun oluştu!", new List<string>
            {
                Messages.CarShouldHaveMin0DailyPrice,
                Messages.CarShouldHaveMin2Character
            });
        }

        public IResult DeleteById(int carId)
        {
            _carDal.Delete(_carDal.Get(c => c.CarId == carId));
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetAllCarsBetweenMinAndMax(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice < max && c.DailyPrice > min), "Başarılı!");
        }

        public IDataResult<List<Car>> GetAllCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetAllCarsIfExist()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.IsActive == true));
        }

        public IDataResult<List<Car>> GetAllCarsIfExist(bool control)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.IsActive == control));
        }

        public IDataResult<List<Car>> GetAllCarsIfNotRented()
        {
            var result = new SuccessDataResult<List<Car>>(_carDal.GetAll(c => !c.Rentals.Any(r => r.ReturnDate == null)));
            return result;
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarsWithDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetAllCarsWithDetails());
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<CarDetailsDto> GetCarWithDetailById(int carId)
        {
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetCarWithDetailById(carId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}