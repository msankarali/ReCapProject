using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        /// <summary>
        /// returns true if rented more than 100
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public IResult CheckIfRentedMoreThanHundred(int carId)
        {
            if (_rentalDal.GetAll(r => r.CarId == carId).Count > 100)
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
    }
}