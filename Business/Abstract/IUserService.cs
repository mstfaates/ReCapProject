﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int userId);

        IDataResult<List<User>> GetByEmail(string email);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
