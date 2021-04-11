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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
                    join b in context.Brands
                        on c.BrandId equals b.BrandId


                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandId = b.BrandId,
                        ColorId = co.ColorId,
                        BrandName = b.Name,
                        DailyPrice = c.DailyPrice,
                        ColorName = co.Name,
                        ImagePath = (from carImage in context.CarImages where carImage.CarId == c.CarId select carImage.ImagePath).FirstOrDefault(),
                        ModelYear = c.ModelYear,
                        Description = c.Description,
                        Status = !context.Rentals.Any(r => r.CarId == c.CarId && (r.ReturnDate == null || r.ReturnDate > DateTime.Now)),
                        FindexPoint = c.FindexPoint
                    };
                return result.ToList();
            }
        }

        
    }
}
