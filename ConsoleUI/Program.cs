using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("CarID: {0}\nBrandID: {1}\nColorID: {2}\nModelYear: {3}\nDailyPrice: {4}\nDescription: {5}\n-----------------------------------------",
                        car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
