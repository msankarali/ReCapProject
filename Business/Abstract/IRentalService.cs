using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Rent(int carId, int customerId);
    }
}