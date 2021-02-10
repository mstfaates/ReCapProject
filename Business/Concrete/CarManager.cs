using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba başarıyla kaydedildi.");
            }
            else
            {
                Console.WriteLine("Araba adı 2 den büyük ve günlük fiyat değeri 0'dan büyük olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba Başarıyla Silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(x => x.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.getCarDetail();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(x => x.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(x => x.ColorId == ColorId);
        }

        public void Update(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("{0} nesnesi başarıyla güncellendi.", car.CarId);
            }
            else
            {
                Console.WriteLine("Güncellenirken hata oluştu. Araba adını 2 karakterden büyük ve günlük ücretin 0 dan büyük olduğundan emin olun.");
            }

        }
    }
}
