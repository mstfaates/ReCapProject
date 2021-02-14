using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId
                    select new CarDetailDto
                    {
                        Model = c.Model,
                        BrandName = b.Name,
                        ColorName = co.Name,
                        DailyPrice = c.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
