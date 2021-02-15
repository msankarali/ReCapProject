using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

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

        IDataResult<List<BrandGetListWithCarsDto>> GetBrand();
    }
}