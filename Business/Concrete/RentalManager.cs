using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Rent(int carId, int customerId)
        {
            //var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            var result2 = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            //var result2 = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Last();

            //if (result.Count > 0)
            //{
            //    return new ErrorResult("Bu araç şuan kullanımda olduğu için kiralanamaz!");
            //}

            if (result2.ReturnDate == null)
            {
                return new ErrorResult("Bu araç şuan kullanımda olduğu için kiralanamaz!");
            }

            _rentalDal.Add(new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            return new SuccessResult("Araç kiralama işlemi başarılı!");

        }
    }
}
