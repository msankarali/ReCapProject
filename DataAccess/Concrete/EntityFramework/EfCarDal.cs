using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetAllCarsWithDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                return (from car in context.Cars
                        join color in context.Colors on car.ColorId equals color.ColorId
                        join brand in context.Brands on car.BrandId equals brand.BrandId
                        select new CarDetailsDto
                        {
                            Brand = brand.BrandName,
                            Color = color.ColorName,
                            DailyPrice = car.DailyPrice,
                            Description = car.Description,
                            ModelYear = car.ModelYear
                        }).ToList();
            }
        }
    }
}
