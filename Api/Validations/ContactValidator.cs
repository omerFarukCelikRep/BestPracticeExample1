using FluentValidation;
using Models;

namespace Api.Validations
{
    public class ContactValidator : AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id can not be greater than 100 !");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Name can not be empty!");
        }
    }
}
