

using Entities.DTOs;
using FluentValidation;
using System.Linq;

namespace Business.ValidationTools.FluentValidation
{
    public class AddCarImagesDtoValidator : AbstractValidator<AddCarImagesDto>
    {
        public AddCarImagesDtoValidator()
        {
            //When(aci => aci.CarId == 0, () =>
            //{
            //    RuleForEach(aci => aci.CarImages.Select(ci => ci.FileName.ToLower()))
            //        .Must(ci => ci.EndsWith(".jpg") || ci.EndsWith(".png") || ci.EndsWith(".jpeg"));
            //}).Otherwise(() =>
            //{
            //    RuleFor(aci => aci.CarId).GreaterThanOrEqualTo(0);
            //    RuleForEach(aci => aci.CarImages.Select(ci => ci.FileName.ToLower()))
            //        .Must(ci => ci.EndsWith(".jpg"));
            //});

            /*
             Could not infer property name for expression: aci => aci.CarImages.Select(ci => ci.FileName). Please explicitly specify a property name by calling OverridePropertyName as part of the rule chain. Eg: RuleForEach(x => x).NotNull().OverridePropertyName("MyProperty")'
              */
            RuleForEach(aci => aci.CarImages)
                .Must(ci => ci.FileName.EndsWith(".jpg") || ci.FileName.EndsWith(".png") || ci.FileName.EndsWith(".jpeg"));

            //-meli -malı
            RuleForEach(aci => aci.CarImages)
                .Must(ci => ci.Length < 1024 * 1024 * 2).WithMessage("Her bir resim için resim boyutu 2Mb'tan küçük olmalı.");

        }
    }
}
