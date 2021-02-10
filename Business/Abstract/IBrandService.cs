﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int carId);
        Brand GetByName(string colorName);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
