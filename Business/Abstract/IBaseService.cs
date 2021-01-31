
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : IEntity
    {
        List<T> GetAll();
        string Add(T item);
        void CheckId(T item);
    }
}
