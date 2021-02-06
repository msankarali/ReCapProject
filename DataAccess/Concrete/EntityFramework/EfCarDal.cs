using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Set<Car>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> predicate)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(predicate);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> predicate = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return predicate == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(predicate).ToList();
            }
        }

        public Car GetById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(b => b.CarId == id);
            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }

    }
}
