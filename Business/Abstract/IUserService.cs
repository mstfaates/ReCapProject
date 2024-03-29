﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IResult Add(User user);

        IResult Delete(User user);

        IResult Update(User user);

        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int id);

        List<OperationClaim> GetClaims(User user);

        User GetByMail(string mail);

        IDataResult<User> GetLastUser();
    }
}
