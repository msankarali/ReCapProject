using Business.Abstract;
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
        public IActionResult Rent(int carId, int customerId)
        {
            var result = _rentalService.Rent(carId, customerId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("ReturnCar")]
        public IActionResult ReturnCar(int carId, int customerId)
        {
            var result = _rentalService.ReturnCar(carId, customerId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetRentedCars()
        {
            var result = _rentalService.GetAllRentedCars();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}