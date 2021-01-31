using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());

            carService.CheckId(new Car
            {
                Id = 0,
                BrandId = 2,
                ColorId = 4,
                DailyPrice = 599,
                Description = "TESLA",
                ModelYear = 2021
            });

            carService.CheckId(new Car
            {
                Id = 2,
                BrandId = 2,
                ColorId = 4,
                DailyPrice = 499,
                Description = "TESLA 2",
                ModelYear = 2010
            });

            carService.CheckId(new Car
            {
                BrandId = 2,
                ColorId = 5,
                DailyPrice = 300,
                Description = "TESLA 5",
                ModelYear = 2008
            });


            foreach (var car in carService.GetAll())
            {
                Console.WriteLine($"{car.Id} {car.BrandId} {car.ModelYear} {car.Description} {car.DailyPrice}");
            }
        }
    }
}
