using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IBrandService brandService = new BrandManager(new EfBrandDal());
            IColorService colorService = new ColorManager(new EfColorDal());
            ICarService carService = new CarManager(new EfCarDal());

            var brandEntity = brandService.GetByBrandName("Audi");
            Console.WriteLine(brandEntity.BrandName);

            foreach (var car in colorService.GetAllColors())
            {
                Console.WriteLine($"{car.ColorName}");
            }

            foreach (var car in carService.GetAll())
            {
                Console.WriteLine($"{car.CarId} {car.BrandId} {car.ModelYear} {car.Description} {car.DailyPrice}");
            }

            foreach (var brand in brandService.GetAllBrands())
            {
                Console.WriteLine($"{brand.BrandName}");
            }

            foreach (var car in carService.GetAllCarsWithDetails())
            {
                Console.WriteLine($"{car.Color} {car.Brand} {car.DailyPrice} {car.Description} {car.ModelYear}");
            }
        }
    }
}
