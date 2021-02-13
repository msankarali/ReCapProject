using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
    }
}
