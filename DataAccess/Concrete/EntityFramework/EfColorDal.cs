using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Set<Color>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> predicate)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Color>().SingleOrDefault(predicate);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> predicate = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return predicate == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(predicate).ToList();
            }
        }

        public Color GetById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Color>().SingleOrDefault(b => b.ColorId == id);
            }
        }

        public void Update(Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }
    }
}
