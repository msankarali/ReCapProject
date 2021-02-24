using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Rent(int carId, int customerId);
        IResult ReturnCar(int carId, int customerId);

        //eğer araç 100 kere kiralanmamışsa, aracı silme işlemini iptal et
        IResult CheckIfRentedCarReachedMaxRentLimit(int carId);

    }
}
