using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join cs in context.Customers on r.CustomerId equals cs.CustomerId
                             join u in context.Users on cs.UserId equals u.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CompanyName = cs.CompanyName,
                                 CarModelYear = c.ModelYear,
                                 CarDailyPrice = c.DailyPrice,
                                 CarDescription = c.Description,
                                 CarId = r.CarId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
