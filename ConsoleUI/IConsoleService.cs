using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace ConsoleUI
{
    public interface IConsoleService
    {
        void GetMenus(string[] menus);

        void GetAllBrands(List<Brand> brands);

        void GetAllColors(List<Color> colors);

        void GetAllCars(List<CarDetailsDto> cars);
        void GetAllUsers(List<User> users);
        void GetAllCustomers(List<Customer> users);

        void GetAllCarsIfNotRented(List<Car> cars);
    }
}