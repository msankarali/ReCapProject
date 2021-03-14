using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetAllCustomersWithDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = context.Customers
                    .Include(c => c.User)
                    .Select(c => new CustomerDetailsDto
                    {
                        CompanyName = c.CompanyName,
                        Email = c.User.Email,
                        FullName = c.User.FirstName + ' ' + c.User.LastName
                    });

                return result.ToList();
            }
        }
    }
}