using Business.Abstract;
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
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        public IActionResult Rent(int carId, int customerId)
        {
            var result = _rentalService.Rent(carId, customerId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult ReturnCar(int carId, int customerId)
        {
            var result = _rentalService.ReturnCar(carId, customerId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
