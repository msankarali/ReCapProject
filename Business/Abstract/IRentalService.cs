using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Rent(Rental rental);
        IResult ReturnCar(Rental rental);

        //eğer araç 100 kere kiralanmamışsa, aracı silme işlemini iptal et
        IResult CheckIfRentedCarReachedMaxRentLimit(int carId);
        IDataResult<List<RentalDetailsDto>> GetAllRentedCars();

    }
}
