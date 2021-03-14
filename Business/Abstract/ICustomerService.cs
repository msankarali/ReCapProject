using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IDataResult<List<Customer>> GetAllCustomers();
        IDataResult<int> GetUserIdByCustomerId(int customerId);
        IDataResult<List<CustomerDetailsDto>> GetAllCustomersWithDetails();
    }
}