using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult("Marka başarıyla eklendi!");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Silme işlemi başarılı!");
        }

        public IDataResult<Brand> GetByBrandName(string brandName)
        {
            var data = _brandDal.Get(b => b.BrandName == brandName);
            return new SuccessDataResult<Brand>(data, "Sonuç başarılı!");
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), "Marka çekildi!");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2 && brand.BrandName.Length > 100)
            {
                return new ErrorResult(Messages.CarUpdateError, new List<string>
                {
                    Messages.CarShouldHaveMinTwoCharacters,
                    Messages.CarShouldHaveMaxHundredCharacters
                });
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult DeleteById(int brandId)
        {
            var deletedCarEntity = _brandDal.Get(b => b.BrandId == brandId).BrandName;
            _brandDal.Delete(_brandDal.Get(b => b.BrandId == brandId));
            return new SuccessResult($"{deletedCarEntity} markası silindi!");
        }

        public IDataResult<List<BrandGetListWithCarsDto>> GetBrand() =>
            new SuccessDataResult<List<BrandGetListWithCarsDto>>(_brandDal.GetListWithCars());

    }
}