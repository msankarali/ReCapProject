using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        private readonly ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult AddCarImages(string[] imageUrls, int carId)
        {
            var result = BusinessRules.Run(
                CheckIfCarImagesMoreThanFive(imageUrls.Length, carId)
                );

            if (result == null)
            {
                foreach (var imageUrl in imageUrls)
                {
                    _carImagesDal.Add(new CarImage
                    {
                        CarId = carId,
                        ImagePath = imageUrl
                    });
                }

                return new SuccessResult(Messages.CarImagesAdded);
            }
            return new ErrorResult(result.Message);
        }

        public IResult DeleteCarImageById(int carImageId)
        {
            _carImagesDal.Delete(_carImagesDal.Get(ci => ci.CarImageId == carImageId));
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var result = _carImagesDal.GetAll(ci => ci.CarId == carId);

            if (!result.Any())
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage
                    {
                        ImagePath = "default.png" //TODO: apng isimli gifimsi png
                    }
                });
            }

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult UpdateCarImage(CarImage carImage)
        {
            var entityToUpdate = _carImagesDal.Get(ci => ci.CarImageId == carImage.CarImageId);
            entityToUpdate.ImagePath = carImage.ImagePath;
            _carImagesDal.Update(entityToUpdate);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImagesMoreThanFive(int totalImageNumber, int carId)
        {
            if (_carImagesDal.GetAll(ci => ci.CarId == carId).Count + totalImageNumber <= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImagesNotAdded);
        }
    }
}
