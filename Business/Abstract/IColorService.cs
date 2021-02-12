﻿using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);
        IDataResult<Color> GetByName(string colorName);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
