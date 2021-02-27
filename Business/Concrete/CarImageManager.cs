using Business.Abstract;
using Business.Constants;
using Business.ValidationTools.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImagesDal _carImagesDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager(
            ICarImagesDal carImagesDal,
            IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(AddCarImagesDtoValidator))]
        public IResult AddCarImages(AddCarImagesDto addCarImagesDto)
        {
            var result = BusinessRules.Run(
                CheckIfCarImagesMoreThanFive(addCarImagesDto.CarImages.Length, addCarImagesDto.CarId),
                CheckIfImageFile(addCarImagesDto.CarImages)

                );

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var imageUrls = _fileHelper.WriteFile(Consts.ImageUploadUrl, addCarImagesDto.CarImages);

            foreach (var imageUrl in imageUrls)
            {
                _carImagesDal.Add(new CarImage
                {
                    CarId = addCarImagesDto.CarId,
                    ImagePath = imageUrl
                });
            }

            return new SuccessResult(Messages.CarImagesAdded);
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

        public IResult UpdateCarImage(UpdateCarImageDto updateCarImageDto)
        {
            var result = BusinessRules.Run(
               CheckIfImageFile(updateCarImageDto.CarImage)

               );

            if (result != null) return result;

            var imageUploadResult = _fileHelper.WriteFile(Consts.ImageUploadUrl, updateCarImageDto.CarImage);

            var entityToUpdate = _carImagesDal.Get(ci => ci.CarImageId == updateCarImageDto.CarImageId);
            entityToUpdate.ImagePath = imageUploadResult[0];

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

        private IResult CheckIfImageFile(params IFormFile[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                var extension = Path.GetExtension(file[i].FileName);
                bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
                if (!result) return new ErrorResult(Messages.FileExtensionMustBeAnImage);
            }
            return new SuccessResult();
        }
    }
}
