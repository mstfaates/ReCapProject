using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constrants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _ıUserDal;

        public UserManager(IUserDal ıUserDal)
        {
            _ıUserDal = ıUserDal;
        }

        public IResult Add(User user)
        {
            _ıUserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _ıUserDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_ıUserDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_ıUserDal.Get(u => u.Email == email));
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_ıUserDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            _ıUserDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
