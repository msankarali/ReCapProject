
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        List<Car> GetAllCarsByBrandId(int brandId);
        List<Car> GetAllCarsByColorId(int colorId);
    }
}
