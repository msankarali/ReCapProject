using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManageer : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManageer(ICustomerDal customerDal)
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
    }
}

//TODO: Clean Code, Manager'da ki metodların içini doldurmayın, attribute oluşturun