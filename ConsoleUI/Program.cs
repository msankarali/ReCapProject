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

            carService.Add(new Car
            {
                Id = 6,
                BrandId = 5,
                ColorId = 6,
                DailyPrice = 599,
                Description = "TESLA",
                ModelYear = 2021
            });

            carService.Add(new Car
            {
                Id = 7,
                BrandId = 5,
                ColorId = 6,
                DailyPrice = 499,
                Description = "TESLA 2",
                ModelYear = 2010
            });


            foreach (var car in carService.GetAll())
            {
                Console.WriteLine($"{car.Id} {car.BrandId} {car.ModelYear} {car.Description} {car.DailyPrice}");
            }
        }
    }
}
