using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByImageId(int id);
        IResult Add(CarImage carImage, IFormFile file);
        IResult Update(CarImage carImage, IFormFile file);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<CarImage> Get(int id);

    }
}
