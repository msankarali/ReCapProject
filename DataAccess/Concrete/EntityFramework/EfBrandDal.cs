using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapContext>, IBrandDal
    {
        public List<BrandGetListWithCarsDto> GetListWithCars()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var denemeeQuery = context.Brands
                    .Include(b => b.Cars)
                    .ThenInclude(c => c.Color).ToList();

                //bulk insert

                var listOfBrandsWithCars = context.Brands
                    .Include(b => b.Cars)
                    .Select(b => new BrandGetListWithCarsDto
                    {
                        BrandName = b.BrandName,
                        CarList = b.Cars
                    }).ToList();

                //TODO: DTO icerisinde entitinin kendisini kullanmak??

                //var listOfBrandsWithCars = context.Brands
                //    .Include(b => b.Cars).ToList();
                //var result = new List<BrandGetListWithCarsDto>();
                //foreach (var item in listOfBrandsWithCars)
                //{
                //    var carList = new List<BrandGetListWithCarsDto_CarItem>();
                //    foreach (var carItem in item.Cars)
                //    {
                //        carList.Add(new BrandGetListWithCarsDto_CarItem
                //        {
                //            CarName = carItem.CarName,
                //            ModelYear = carItem.ModelYear
                //        });
                //    }
                //    result.Add(new BrandGetListWithCarsDto
                //    {
                //        BrandName = item.BrandName,
                //        CarList = carList
                //    });

                return listOfBrandsWithCars;
            }
        }
    }
}