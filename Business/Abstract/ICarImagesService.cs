using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IResult AddCarImages(string[] imageUrls, int carId);
        IResult DeleteCarImageById(int carImageId);
        IResult UpdateCarImage(CarImage carImage);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
    }
}
