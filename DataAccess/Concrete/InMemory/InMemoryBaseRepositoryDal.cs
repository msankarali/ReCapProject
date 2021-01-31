using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public abstract class InMemoryBaseRepositoryDal<T> : IRepositoryDal<T> where T : IEntity
    {
        List<T> _tList;
        public InMemoryBaseRepositoryDal()
        {
            _tList = new List<T>();
        }
        public void Add(T item)
        {
            _tList.Add(item);
        }

        public void Delete(T item)
        {
            T itemToDelete = _tList.SingleOrDefault(t => t.Id == item.Id);
            _tList.Remove(itemToDelete);
        }

        public T FindById(int id)
        {
            return _tList.SingleOrDefault(t => t.Id == id);
        }

        public List<T> GetAll()
        {
            return _tList;
        }

        public abstract void Update(T item);
    }
}
