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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Set<Brand>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> predicate)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Brand>().SingleOrDefault(predicate);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> predicate = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return predicate == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(predicate).ToList();
            }
        }

        public Brand GetById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Brand>().SingleOrDefault(b => b.BrandId == id);
            }
        }

        public void Update(Brand entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }
    }
}
