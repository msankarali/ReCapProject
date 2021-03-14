using Core.DataAccess.EntityFramework;
using Core.Extensions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        //public List<CarDetailsDto> GetAllCarsWithDetails()
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        return (from car in context.Cars
        //                join color in context.Colors on car.ColorId equals color.ColorId into temp
        //                from t in temp.DefaultIfEmpty()
        //                join brand in context.Brands on car.BrandId equals brand.BrandId into temp2
        //                from t2 in temp2.DefaultIfEmpty()
        //                select new CarDetailsDto
        //                {
        //                    BrandName = t2.BrandName == null ? "Marka yok" : t2.BrandName,
        //                    ColorName = t.ColorName == null ? "Renk yok" : t.ColorName,
        //                    DailyPrice = car.DailyPrice,
        //                    CarName = car.CarName,
        //                    CarId = car.CarId,
        //                    Description = car.Description,
        //                    ModelYear = car.ModelYear
        //                }).ToList();
        //    }
        //}

        public List<CarDetailsDto> GetAllCarsWithDetails(CarFilterDto carFilterDto)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var query = context.Cars
                    .Include(c => c.Color)
                    .Include(c => c.Brand)
                    .WhereIf(carFilterDto.brandId.HasValue, c => c.Brand.BrandId == carFilterDto.brandId)
                    .WhereIf(carFilterDto.colorId.HasValue, c => c.Color.ColorId == carFilterDto.colorId)
                    .WhereIf(carFilterDto.MinPrice.HasValue, c => c.DailyPrice > carFilterDto.MinPrice)
                    .WhereIf(carFilterDto.MaxPrice.HasValue, c => c.DailyPrice < carFilterDto.MaxPrice)
                    .Select(c => new CarDetailsDto
                    {
                        BrandName = c.Brand.BrandName == null ? "Marka yok" : c.Brand.BrandName,
                        ColorName = c.Color.ColorName == null ? "Renk yok" : c.Color.ColorName,
                        DailyPrice = c.DailyPrice,
                        CarName = c.CarName,
                        CarId = c.CarId,
                        Description = c.Description,
                        IsDeleted = c.IsActive,
                        ModelYear = c.ModelYear
                    });

                return result.ToList();
            }
        }

        public CarDetailsDto GetCarWithDetailById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailsDto
                             {
                                 BrandName = brand.BrandName,
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };

                return result.SingleOrDefault(c => c.CarId == carId);
            }
        }
    }
}