using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void AddBrand(Brand brand);
        Brand GetById(int id);
        void Delete(Brand brand);
        Brand GetByBrandName(string brandName);
        List<Brand> GetAllBrands();
    }
}
