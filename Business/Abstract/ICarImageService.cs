using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddCarImages(AddCarImagesDto addCarImagesDto);
        IResult DeleteCarImageById(int carImageId);
        IResult UpdateCarImage(UpdateCarImageDto updateCarImageDto);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IDataResult<CarImage> GetCarPreviewImageByCarId(int carId);
    }
}
