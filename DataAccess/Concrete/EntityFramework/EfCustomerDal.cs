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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 UserName = u.FirstName + u.LastName,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
