using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBaseRepositoryDal<T> : IRepositoryDal<T> where T : IEntity
    {
        public void Add(T item)
        {

        }

        public void Delete(T item)
        {

        }

        public T FindById(int id)
        {
            throw new NotImplementedException();

        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {

        }
    }
}
