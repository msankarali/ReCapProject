using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);

        User GetByMail(string email);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetUser(int userId);
    }
}
