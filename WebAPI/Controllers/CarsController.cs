using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCarsByBrandId(int brandId)
        {
            var result = _carService.GetAllCarsByBrandId(brandId);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCarsByColorId(int colorId)
        {
            var result = _carService.GetAllCarsByColorId(colorId);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCarById(int carId)
        {
            var result = _carService.GetCarById(carId);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCarsWithDetails()
        {
            var result = _carService.GetAllCarsWithDetails();
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCarsBetweenMinAndMax(int min, int max)
        {
            var result = _carService.GetAllCarsBetweenMinAndMax(min, max);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCarsIfExist()
        {
            var result = _carService.GetAllCarsIfExist();
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCarsIfExist(bool control)
        {
            var result = _carService.GetAllCarsIfExist(control);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int carId)
        {
            var result = _carService.DeleteById(carId);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCarWithDetailById(int carId)
        {
            var result = _carService.GetCarWithDetailById(carId);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCarsIfNotRented()
        {
            var result = _carService.GetAllCarsIfNotRented();
            if (result.Success) return Ok(result);
            return Ok(result);
        }
    }
}
