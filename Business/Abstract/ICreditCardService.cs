using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();

        IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber);

        IDataResult<List<CreditCard>> GetCardsByCustomerId(int id);

        IResult Update(CreditCard creditCard);

        IResult Add(CreditCard creditCard);

        IResult Delete(CreditCard creditCard);
    }
}
