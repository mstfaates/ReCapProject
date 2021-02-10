using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.Name.Length >= 3)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("Hata. Marka adı en az 3 karakter olmalıdır.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("{0} başarılı bir şekilde silinmiştir.", brand.Name);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
        }

        public Brand GetByName(string brandName)
        {
            return _brandDal.Get(b => b.Name == brandName);
        }

        public void Update(Brand brand)
        {
            if (brand.Name.Length >= 3)
            {
                _brandDal.Add(brand);
                Console.WriteLine("{0} markası başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Hata. marka en az 3 karakter olmalıdır.");
            }
        }
    }
}
