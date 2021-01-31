using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine($"{car.Id} {car.BrandId} {car.ModelYear} {car.Description} {car.DailyPrice}");
            }
        }
    }
}
