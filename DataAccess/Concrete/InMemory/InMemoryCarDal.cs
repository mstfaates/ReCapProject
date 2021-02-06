using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 50000, ModelYear = 2003, Description = "It's a nice car"},
                new Car{CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 60000, ModelYear = 2004, Description = "It's a nice car"},
                new Car{CarId = 3, BrandId = 3, ColorId = 2, DailyPrice = 70000, ModelYear = 2005, Description = "It's a nice car"},
                new Car{CarId = 4, BrandId = 4, ColorId = 2, DailyPrice = 80000, ModelYear = 2006, Description = "It's a nice car"},
                new Car{CarId = 5, BrandId = 5, ColorId = 3, DailyPrice = 90000, ModelYear = 2007, Description = "It's a nice car"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car toBeDeleted = _cars.SingleOrDefault(x => x.CarId == car.CarId);
            _cars.Remove(toBeDeleted);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(x => x.CarId == id).ToList();
        }

        public void Update(Car car)
        {
            Car toBeUpdated = _cars.SingleOrDefault(x => x.CarId == car.CarId);
            toBeUpdated.BrandId = car.BrandId;
            toBeUpdated.ColorId = car.ColorId;
            toBeUpdated.DailyPrice = car.DailyPrice;
            toBeUpdated.ModelYear = car.ModelYear;
            toBeUpdated.Description = car.Description;
        }
    }
}
