using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {

        private readonly ICarImagesService _carImagesService;

        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpPost("Upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upload(IFormFile[] imageFile, int carId)
        {
            string[] savedImageUrls;
            if (CheckIfImageFile(imageFile))
            {
                savedImageUrls = await WriteFile(imageFile);
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Lütfen gerçerli format giriniz!",
                    imageFile
                });
            }

            var result = _carImagesService.AddCarImages(savedImageUrls, carId);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(int carImageId, IFormFile imageFile, int carId)
        {
            string savedImageUrl;
            if (CheckIfImageFile(imageFile))
            {
                savedImageUrl = await WriteFile(imageFile);
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Lütfen gerçerli format giriniz!",
                    imageFile
                });
            }

            var result = _carImagesService.UpdateCarImage(new CarImage
            {
                ImagePath = savedImageUrl,
                CarImageId = carImageId
            });

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        #region Methods

        private bool CheckIfImageFile(IFormFile[] file)
        {
            //bool result = false;
            for (int i = 0; i < file.Length; i++)
            {
                var extension = Path.GetExtension(file[i].FileName);

                //Path.GetExtension()
                //var extension = "." + file[i].FileName.Split('.')[^1];
                //var extension = "." + file[i].FileName.Split('.')[file[i].FileName.Split('.').Length - 1];
                //string fileExtension = carImage.ImagePath.Substring(carImage.ImagePath.IndexOf("."), carImage.ImagePath.Length - carImage.ImagePath.IndexOf("."));

                bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
                if (!result) return false;
            }
            return true;
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);

            bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
            if (!result) return false;

            return true;
        }

        private async Task<string[]> WriteFile(IFormFile[] file)
        {
            string[] savedImageUrls = new string[file.Length];
            string fileName;

            for (int i = 0; i < file.Length; i++)
            {
                var extension = Path.GetExtension(file[i].FileName);
                //var extension = "." + file[i].FileName.Split('.')[file[i].FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid() + extension;

                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\upload\images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file[i].CopyToAsync(stream);
                }

                savedImageUrls[i] = fileName;
            }

            return savedImageUrls;
        }

        private async Task<string> WriteFile(IFormFile file)
        {
            string fileName;

            var extension = Path.GetExtension(file.FileName);

            fileName = Guid.NewGuid() + extension;

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\upload\images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        #endregion
    }
}
