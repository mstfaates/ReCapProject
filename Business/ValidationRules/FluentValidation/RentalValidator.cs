using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty();
            //RuleFor(r => r.ReturnDate).Must(ReturnDateComparison).WithMessage("Geri teslimat tarihi kiralama tarihinden önce olamaz");
        }

    }
}
