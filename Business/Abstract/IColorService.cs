using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAllColors();
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);
        Color GetById(int colorId);
        void DeleteById(int colorId);
    }
}
