using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<int> GetAllIds(Expression<Func<Rental, bool>> predicate)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Rentals.Where(predicate).Select(c => c.CarId).ToList();
            }
        }

        public List<RentalDetailsDto> GetAllRentedCars()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = context.Rentals
                    .Include(r => r.Car)
                        .ThenInclude(c => c.Brand)
                    .Include(r => r.Customer)
                    .Select(r => new RentalDetailsDto
                    {
                        BrandName = r.Car.Brand.BrandName,
                        FullName = r.Customer.User.FirstName + r.Customer.User.LastName,
                        RentalId = r.RentalId
                    }).ToList();

                return result;
            }
        }
    }
}
