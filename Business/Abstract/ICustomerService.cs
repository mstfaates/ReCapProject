using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<Customer> GetByUserId(int id);
        IDataResult<Customer> GetByCustomerName(string name);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
