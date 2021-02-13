using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class ConsoleManager : IConsoleService
    {
        public void GetAllBrands(List<Brand> brands)
        {
            Console.WriteLine("******************************");
            foreach (var brand in brands)
            {
                Console.WriteLine($"{brand.BrandId} {brand.BrandName}");
            }
            Console.WriteLine("******************************");
        }

        public void GetAllCars(List<CarDetailsDto> cars)
        {
            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.CarId}\t{car.ModelYear}\t{car.BrandName}\t{car.CarName}\t{car.ColorName}\t{car.Description}");
            }
            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
        }

        public void GetAllCarsIfNotRented(List<Car> cars)
        {
            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.CarId}\t{car.ModelYear}\t{car.CarName}\t{car.Description}");
            }
            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
        }

        public void GetAllColors(List<Color> colors)
        {
            Console.WriteLine("******************************");
            foreach (var color in colors)
            {
                Console.WriteLine($"{color.ColorId} {color.ColorName}");
            }
            Console.WriteLine("******************************");
        }

        public void GetMenus(string[] menus)
        {
            Console.WriteLine("------------------------------");
            for (int i = 0; i < menus.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menus[i]}");
            }
            Console.WriteLine("------------------------------");
        }
    }
}