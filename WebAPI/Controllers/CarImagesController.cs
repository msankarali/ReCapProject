using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImagesService;

        public CarImagesController(ICarImageService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpPost("Upload")]
        public IActionResult Upload([FromForm] AddCarImagesDto addOrUpdateCarImagesDto)
        {
            var result = _carImagesService.AddCarImages(addOrUpdateCarImagesDto);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] UpdateCarImageDto updateCarImageDto)
        {
            var result = _carImagesService.UpdateCarImage(updateCarImageDto);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetCarPreviewImageByCarId")]
        public IActionResult GetCarPreviewImageByCarId(int carId)
        {
            var result = _carImagesService.GetCarPreviewImageByCarId(carId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}