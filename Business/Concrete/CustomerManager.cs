using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult("Başarılı!");
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<CustomerDetailsDto>> GetAllCustomersWithDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetAllCustomersWithDetails());
        }

        public IDataResult<int> GetUserIdByCustomerId(int customerId)
        {
            return new SuccessDataResult<int>(_customerDal.Get(c => c.CustomerId == customerId).UserId);
        }
    }
}

//TODO: Clean Code, Manager'da ki metodların içini doldurmayın, attribute oluşturun

