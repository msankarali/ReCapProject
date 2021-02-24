﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;

        public RentalManager(
            IRentalDal rentalDal,
            IUserService userService,
            ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _userService = userService;
            _customerService = customerService;
        }

        /// <summary>
        /// returns true if rented more than 100
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public IResult CheckIfRentedCarReachedMaxRentLimit(int carId)
        {
            if (_rentalDal.GetAll(r => r.CarId == carId).Count > 100)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CheckIfRentedCarReachedMaxRentLimit200(int carId)
        {
            if (_rentalDal.GetAll(r => r.CarId == carId).Count > 200)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


        public IResult Rent(int carId, int customerId)
        {
            //var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            var result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            //var result2 = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Last();

            //if (result.Count > 0)
            //{
            //    return new ErrorResult("Bu araç şuan kullanımda olduğu için kiralanamaz!");
            //}

            var rslt = BusinessRules.Run(
                CheckIfUserOlderThanTwenty(_customerService.GetUserIdByCustomerId(customerId).Data)

                );

            if (rslt != null)
            {
                return rslt;
            }

            if (result != null) return new ErrorResult("Bu araç şuan kullanımda olduğu için kiralanamaz!");

            _rentalDal.Add(new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            return new SuccessResult("Araç kiralama işlemi başarılı!");
        }

        public IResult ReturnCar(int carId, int customerId)
        {
            var result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);

            if (result != null) return new ErrorResult(Messages.CarNotGotBack);

            result.ReturnDate = DateTime.Now;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.CarGotBack);
        }

        private IResult CheckIfUserOlderThanTwenty(int userId)
        {
            //Birth Day: 1993 < 2000
            var result = _userService.GetUser(userId).Data.Age < DateTime.Now.AddYears(-20);
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult("YAŞ ENGELİ!");
        }
    }
}