using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        Car GetById(int id);
        List<Car> GetAll();
        void Add();
        void Update();
        void Delete();
    }
}
