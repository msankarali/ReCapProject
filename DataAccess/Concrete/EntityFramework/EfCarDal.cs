﻿using Core.DataAccess.EntityFramework;
using Core.Extensions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
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
            // IRepo, UoW (repos, contexts, transaction-rollback), filter(success, error checking), 
            using (ReCapContext context = new ReCapContext())
            {
                var result = context.Cars
                    .Include(c => c.Color) // class'lara ayirma
                    .Include(c => c.Brand) // IQueryable
                    .Include(c => c.CarImages)
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
                        ModelYear = c.ModelYear,
                        ImageUrl = c.CarImages.Any(ci => ci.CarId == c.CarId) ? c.CarImages.FirstOrDefault(ci => ci.CarId == c.CarId).ImagePath : "no-preview.png"
                    });

                return result.ToList();
            }
        }



        public CarDetailsWithImagesDto GetCarWithDetailById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = context.Cars
                    .Include(c => c.Color) // class'lara ayirma
                    .Include(c => c.Brand) // IQueryable
                    .Include(c => c.CarImages)
                    .Where(c => c.CarId == carId)
                    .Select(c => new CarDetailsWithImagesDto
                    {
                        BrandName = c.Brand.BrandName == null ? "Marka yok" : c.Brand.BrandName,
                        ColorName = c.Color.ColorName == null ? "Renk yok" : c.Color.ColorName,
                        DailyPrice = c.DailyPrice,
                        CarName = c.CarName,
                        CarId = c.CarId,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        CarImages = c.CarImages.Where(ci => ci.CarId == c.CarId).ToList()
                    });

                return result.SingleOrDefault();
            }
        }
    }
}