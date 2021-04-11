using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int carId);

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<CarDetailDto>> GetAllByBrandIdWithDetails(int id);

        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int brandId, int colorId);

        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int id);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
