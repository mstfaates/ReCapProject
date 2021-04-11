using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;
        private ICustomerService _customerService;
        private ICarService _carService;

        public RentalManager(IRentalDal rentaldal, ICarService carService, ICustomerService customerService)
        {
            _rentaldal = rentaldal;
            _carService = carService;
            _customerService = customerService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentaldal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (System.DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll());
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(x => x.RentalId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentaldal.GetRentalDetail());
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult FindexPointCheck(int customerId, int carId)
        {
            var customer = _customerService.GetById(customerId).Data;

            if (customer.FindexPoint == 0)
            {
                return new ErrorResult(Messages.CustomerFindexPointIsZero);
            }

            var car = _carService.GetById(carId).Data;

            if (customer.FindexPoint < car.FindexPoint)
            {
                return new ErrorResult(Messages.CustomerScoreInvalid);
            }

            customer.FindexPoint = (car.FindexPoint / 2) + customer.FindexPoint;

            _customerService.Update(customer);
            return new SuccessResult();
        }
    }
}
