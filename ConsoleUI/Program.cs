using Business.Abstract;
using Business.Concrete;
using Business.ValidationTools.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IBrandService brandService = new BrandManager(new EfBrandDal());
            IColorService colorService = new ColorManager(new EfColorDal());
            ICarService carService = new CarManager(new EfCarDal());
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            ICustomerService customerService = new CustomerManageer(new EfCustomerDal());
            IConsoleService consoleService = new ConsoleManager();


            var brandsWithCars = brandService.GetBrand();

            foreach (var brand in brandsWithCars)
            {
                Console.Write(brand.BrandName + " => ");
                foreach (var car in brand.CarList)
                {
                    Console.Write(car.CarName);
                }
                Console.WriteLine();
            }


            //brandService.GetBrand();

            var menus = new string[]
            {
                "Marka ekle", "Markaları listele", "Marka sil", "Marka getir", "Marka güncelle",
                "Renk ekle", "Renkleri listele", "Renk sil", "Renk getir", "Renk güncelle",
                "Araba ekle", "Arabaları listele", "Araba sil", "Araba getir", "Araba güncelle",
                "Müşteri Ekle", "Araba Kirala"

            };

            string input = "";
            int inputId = 0;

            while (true)
            {
                consoleService.GetMenus(menus);
                Console.Write("Seçiminiz: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Lütfen eklemek istediğiniz marka adını giriniz: ");
                        brandService.Add(new Brand
                        {
                            BrandName = Console.ReadLine()
                        });
                        break;
                    case "2":
                        Console.Clear();
                        consoleService.GetAllBrands(brandService.GetAll().Data);
                        break;
                    case "3":
                        Console.Clear();
                        consoleService.GetAllBrands(brandService.GetAll().Data);
                        Console.Write("Lütfen silmek istediğiniz markanın Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        brandService.DeleteById(inputId);
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Lütfen getirmek istediğiniz Marka Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        var brandEntity = brandService.GetById(inputId).Data;
                        Console.WriteLine("Marka ismi: " + brandEntity.BrandName);
                        break;
                    case "5":
                        Console.Clear();
                        consoleService.GetAllBrands(brandService.GetAll().Data);
                        Console.Write("Lütfen güncellemek istediğiniz Marka Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        var brandEntityToUpdate = brandService.GetById(inputId).Data;
                        Console.WriteLine("Marka ismi: " + brandEntityToUpdate.BrandName);
                        Console.Write("Lütfen güncel Marka adını giriniz: ");
                        brandEntityToUpdate.BrandName = Console.ReadLine();
                        brandService.Update(brandEntityToUpdate);
                        break;

                    case "6":
                        Console.Clear();
                        Console.Write("Lütfen renk giriniz: ");
                        colorService.Add(new Color
                        {
                            ColorName = Console.ReadLine()
                        });
                        break;
                    case "7":
                        Console.Clear();
                        consoleService.GetAllColors(colorService.GetAllColors().Data);
                        break;
                    case "8":
                        Console.Clear();
                        consoleService.GetAllColors(colorService.GetAllColors().Data);
                        Console.Write("Lütfen silmek istediğiniz Rengin Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        var result = colorService.DeleteById(inputId);
                        if (!result.Success)
                        {
                            Console.WriteLine("Hata mesaji: {0}", result.Message);
                            foreach (var error in result.Errors) Console.WriteLine(error);
                        }

                        break;
                    case "9":
                        Console.Clear();
                        Console.Write("Lütfen getirmek istediğiniz Renk Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        var colorEntity = colorService.GetById(inputId).Data;
                        Console.WriteLine("Marka ismi: " + colorEntity.ColorName);
                        break;
                    case "10":
                        Console.Clear();
                        consoleService.GetAllColors(colorService.GetAllColors().Data);
                        Console.Write("Lütfen güncellemek istediğiniz Renk Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        var colorEntityToUpdate = colorService.GetById(inputId).Data;
                        Console.WriteLine("Marka ismi: " + colorEntityToUpdate.ColorName);
                        Console.Write("Lütfen güncel Renk adını giriniz: ");
                        colorEntityToUpdate.ColorName = Console.ReadLine();
                        colorService.Update(colorEntityToUpdate);
                        break;

                    case "11":
                        Console.Clear();
                        var carEntityToAdd = new Car();

                        Console.Write("Lütfen arabanın adını yazınız: ");
                        carEntityToAdd.CarName = Console.ReadLine();

                        consoleService.GetAllBrands(brandService.GetAll().Data);
                        Console.Write("Lütfen arabanın Marka Id'sini giriniz: ");
                        carEntityToAdd.BrandId = int.Parse(Console.ReadLine());

                        consoleService.GetAllColors(colorService.GetAllColors().Data);
                        Console.Write("Lütfen arabanın Renk Id'sini giriniz: ");
                        carEntityToAdd.ColorId = int.Parse(Console.ReadLine());

                        Console.Write("Lütfen arabanın günlük ücretini giriniz: ");
                        carEntityToAdd.DailyPrice = decimal.Parse(Console.ReadLine());

                        Console.Write("Lütfen arabanın açıklamasını giriniz: ");
                        carEntityToAdd.Description = Console.ReadLine();

                        Console.Write("Lütfen arabanın model yılını giriniz: ");
                        carEntityToAdd.ModelYear = short.Parse(Console.ReadLine());

                        CarValidator carValidator = new CarValidator();
                        if (!HasError(carValidator.Validate(carEntityToAdd))) carService.Add(carEntityToAdd);
                        break;
                    case "12":
                        Console.Clear();
                        consoleService.GetAllCars(carService.GetAllCarsWithDetails().Data);
                        break;
                    case "13":
                        Console.Clear();
                        consoleService.GetAllCars(carService.GetAllCarsWithDetails().Data);
                        Console.Write("Lütfen silmek istediğiniz arabanın Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        carService.DeleteById(inputId);
                        break;
                    case "14":
                        Console.Clear();
                        Console.Write("Lütfen getirmek istediğiniz arabanın Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        var carEntity = carService.GetCarWithDetailById(inputId).Data;
                        Console.WriteLine($"{carEntity.CarId}\t{carEntity.ModelYear}\t{carEntity.BrandName}\t{carEntity.CarName}\t{carEntity.ColorName}\t{carEntity.Description}");
                        break;
                    case "15":
                        Console.Clear();
                        consoleService.GetAllCars(carService.GetAllCarsWithDetails().Data);
                        Console.Write("Lütfen güncellemek istediğiniz arabanın Id'sini giriniz: ");
                        inputId = int.Parse(Console.ReadLine());
                        var carEntityInfo = carService.GetCarWithDetailById(inputId).Data;
                        Console.WriteLine($"{carEntityInfo.CarId}\t{carEntityInfo.ModelYear}\t{carEntityInfo.BrandName}\t{carEntityInfo.CarName}\t{carEntityInfo.ColorName}\t{carEntityInfo.Description}");
                        var carEntityToUpdate = carService.GetCarById(inputId).Data;

                        Console.Write("Lütfen arabanın adını yazınız: ");
                        carEntityToUpdate.CarName = Console.ReadLine();

                        consoleService.GetAllBrands(brandService.GetAll().Data);
                        Console.Write("Lütfen arabanın Marka Id'sini giriniz: ");
                        carEntityToUpdate.BrandId = int.Parse(Console.ReadLine());

                        consoleService.GetAllColors(colorService.GetAllColors().Data);
                        Console.Write("Lütfen arabanın Renk Id'sini giriniz: ");
                        carEntityToUpdate.ColorId = int.Parse(Console.ReadLine());

                        Console.Write("Lütfen arabanın günlük ücretini giriniz: ");
                        carEntityToUpdate.DailyPrice = decimal.Parse(Console.ReadLine());

                        Console.Write("Lütfen arabanın açıklamasını giriniz: ");
                        carEntityToUpdate.Description = Console.ReadLine();

                        Console.Write("Lütfen arabanın model yılını giriniz: ");
                        carEntityToUpdate.ModelYear = short.Parse(Console.ReadLine());

                        carService.Update(carEntityToUpdate);
                        break;
                    case "16":
                        //"Müşteri Ekle", "Araba Kirala"
                        customerService.Add(new Customer
                        {
                            UserId = 1,
                            CompanyName = "MSA"
                        });

                        break;
                    case "17":
                        consoleService.GetAllCarsIfNotRented(carService.GetAllCarsIfNotRented().Data);
                        Console.WriteLine("Lütfen kiralamak istediğiniz arabanın Id'sini giriniz:");
                        inputId = int.Parse(Console.ReadLine());
                        var asd = rentalService.Rent(inputId, 1);
                        Console.WriteLine(asd.Message);
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim yaptınız!");
                        break;
                }
            }

            //Works(brandService, colorService, carService);
        }

        public static bool HasError(ValidationResult result)
        {
            if (!result.IsValid)
            {
                //result.Errors.ToList().ForEach(e => Console.WriteLine(e.ErrorMessage));
                foreach (var error in result.Errors)
                    Console.WriteLine(error.ErrorMessage);

                return true;
            }
            else return false;
        }

        private static void Works(IBrandService brandService, IColorService colorService, ICarService carService)
        {
            Console.WriteLine("Yayında olmayan araçlar");
            foreach (var car in carService.GetAllCarsIfExist(false).Data)
            {
                Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
            }

            Console.WriteLine("Yayında olan araçlar");
            foreach (var car in carService.GetAllCarsIfExist(true).Data)
            {
                Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
            }

            foreach (var car in carService.GetAllCarsIfExist().Data)
            {
                Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
            }

            var brandEntity = brandService.GetByBrandName("Audi").Data;
            Console.WriteLine(brandEntity.BrandName);


            Console.WriteLine("-------");
            foreach (var car in carService.GetAllCarsBetweenMinAndMax(50, 500).Data)
            {
                Console.WriteLine("Araba adı: " + car.CarName + ", Araba ücreti: " + car.DailyPrice + "!!");
                Console.WriteLine($"Araba adı: {car.CarName}, Araba ücreti: {car.DailyPrice}!!");
                Console.WriteLine("Araba adı: {0}, Araba ücreti: {1}!!", car.CarName, car.DailyPrice);
            }
            Console.WriteLine("-------");

            foreach (var car in colorService.GetAllColors().Data)
            {
                Console.WriteLine($"{car.ColorName}");
            }

            foreach (var car in carService.GetAll().Data)
            {
                Console.WriteLine($"{car.CarId} {car.BrandId} {car.ModelYear} {car.Description} {car.DailyPrice}");
            }

            foreach (var brand in brandService.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandName}");
            }

            foreach (var car in carService.GetAllCarsWithDetails().Data)
            {
                Console.WriteLine($"{car.ColorName} {car.BrandName} {car.CarName} {car.DailyPrice}");
            }
        }
    }
}
