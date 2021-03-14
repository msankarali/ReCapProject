using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
        private IRentalService _rentalService;

        public CarManager(
            ICarDal carDal,
            IRentalService rentalService)
        {
            _carDal = carDal;
            _rentalService = rentalService;
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
            var result = BusinessRules.Run(
                CheckIfCarRentedMoreThanHundred(carId)

                );
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

        public IDataResult<List<CarDetailsDto>> GetAllCarsWithDetails(CarFilterDto carFilterDto)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetAllCarsWithDetails(carFilterDto));
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
            var result = BusinessRules.Run(
                CheckIfCarRentedMoreThanHundred(car.CarId),
                CheckIfCarRentedMoreThanHundred(car.CarId),
                CheckIfCarRentedMoreThanHundred(car.CarId),
                CheckIfCarRentedMoreThanHundred(car.CarId)

                );



            //eğer araç 100 kere 
            //bir yıl içerisinde 25 kere kullanılmışsa, servis kontrolü yapılması gerektiğini bildir


            _carDal.Update(car);
            return new SuccessResult();
        }

        #region Business Rules

        private IResult CheckIfCarRentedMoreThanHundred(int carId)
        {
            if (_rentalService.CheckIfRentedCarReachedMaxRentLimit(carId).Success)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        #endregion
    }
}