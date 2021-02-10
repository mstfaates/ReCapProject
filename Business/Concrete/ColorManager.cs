using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.Name.Length >= 3)
            {
                _colorDal.Add(color);
                Console.WriteLine("{0} rengi başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Hata. Renk en az 3 karakter olmalıdır.");
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("{0} rengi başarılı bir şekilde silinmiştir.");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.ColorId == colorId);
        }

        public Color GetByName(string colorName)
        {
            return _colorDal.Get(c => c.Name == colorName);
        }

        public void Update(Color color)
        {
            if (color.Name.Length >= 3)
            {
                _colorDal.Update(color);
                Console.WriteLine("{0} rengi başarılı bir şekilde güncellenmiştir.");
            }
            else
            {
                Console.WriteLine("Hata. Renk en az 3 karakter olmalıdır.");
            }
        }
    }
}
