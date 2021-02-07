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

            Console.WriteLine("Yayında olmayan araçlar");
            foreach (var car in carService.GetAllCarsIfExist(false))
            {
                Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
            }

            Console.WriteLine("Yayında olan araçlar");
            foreach (var car in carService.GetAllCarsIfExist(true))
            {
                Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
            }

            //foreach (var car in carService.GetAllCarsIfExist())
            //{
            //    Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
            //}

            //var brandEntity = brandService.GetByBrandName("Audi");
            //Console.WriteLine(brandEntity.BrandName);


            //Console.WriteLine("-------");
            //foreach (var car in carService.GetAllCarsBetweenMinAndMax(50, 500))
            //{
            //    Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
            //    Console.WriteLine($"Araba adı: {car.CarName}, Araba ücreti: {car.DailyPrice}!!");
            //    Console.WriteLine("Araba adı: {0}, Araba ücreti: {1}!!", car.CarName, car.DailyPrice);
            //}
            //Console.WriteLine("-------");

            //foreach (var car in colorService.GetAllColors())
            //{
            //    Console.WriteLine($"{car.ColorName}");
            //}

            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine($"{car.CarId} {car.BrandId} {car.ModelYear} {car.Description} {car.DailyPrice}");
            //}

            //foreach (var brand in brandService.GetAll())
            //{
            //    Console.WriteLine($"{brand.BrandName}");
            //}

            //foreach (var car in carService.GetAllCarsWithDetails())
            //{
            //    Console.WriteLine($"{car.ColorName} {car.BrandName} {car.CarName} {car.DailyPrice}");
            //}
        }
    }
}
