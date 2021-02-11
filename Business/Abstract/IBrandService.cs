using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<Brand> GetById(int id);
        IResult DeleteById(int id);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetByBrandName(string brandName);
    }
}
