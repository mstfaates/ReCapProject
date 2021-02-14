using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join x in context.Customers on r.CustomerId equals x.CustomerId
                             select new RentalDetailDto
                             {
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 ModelName = c.Model,
                                 CompanyName = x.CompanyName,
                             };
                return result.ToList();
            }
        }
    }
}
