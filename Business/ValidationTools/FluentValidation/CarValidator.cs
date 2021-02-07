using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationTools.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Arabanın günlük fiyatı 0'dan büyük olmalıdır.");
            RuleFor(c => c.CarName.Length).GreaterThan(2).WithMessage("Arabanın adı 2 karakterden büyük olmalı.");
        }
    }
}
