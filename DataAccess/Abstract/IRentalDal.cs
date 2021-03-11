using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<int> GetAllIds(Expression<Func<Rental, bool>> predicate);
        List<RentalDetailsDto> GetAllRentedCars();
    }
}