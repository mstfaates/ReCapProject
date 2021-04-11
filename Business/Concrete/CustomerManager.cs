using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfCompanyNameIsProper(customer.CompanyName));

            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetByCustomerName(string name)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CompanyName == name));
        }

        public IDataResult<CustomerDetailDto> GetByEmail(string email)
        {
            var getByEmail = _customerDal.GetByEmail(user => user.Email == email);
            return new SuccessDataResult<CustomerDetailDto>(getByEmail);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id));
        }

        public IDataResult<Customer> GetByUserId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfCompanyNameIsProper(customer.CompanyName));

            if (result != null)
            {
                return result;
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        private IResult CheckIfCompanyNameIsProper(string companyName)
        {
            if (companyName.Length > 2)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.CustomerNameInvalid);
        }
    }
}
