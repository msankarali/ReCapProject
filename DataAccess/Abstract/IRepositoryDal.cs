using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRepositoryDal<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        List<T> GetAll();
        T FindById(int id);
    }
}
