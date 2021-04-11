using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Rent")]
        public IActionResult Rent(Rental rental)
        {
            var result = _rentalService.Rent(rental);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("ReturnCar")]
        public IActionResult ReturnCar(Rental rental)
        {
            var result = _rentalService.ReturnCar(rental);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetRentedCars")]
        public IActionResult GetRentedCars()
        {
            var result = _rentalService.GetAllRentedCars();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}