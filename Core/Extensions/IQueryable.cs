using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class IQueryable
    {
        public static IQueryable<T> GetKurumId<T>(this IQueryable<T> queryable, int id)
            where T : class, IKurumEntity, new()
        {
            return queryable.Where(k => k.KurumId == id);
        }
    }
}
