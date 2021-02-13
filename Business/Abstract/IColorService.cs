using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAllColors();

        IResult Add(Color color);

        IResult Delete(Color color);

        IResult Update(Color color);

        IDataResult<Color> GetById(int colorId);

        IResult DeleteById(int colorId);
    }
}