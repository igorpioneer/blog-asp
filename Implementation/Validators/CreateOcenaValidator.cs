using Application.DTO;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateOcenaValidator : AbstractValidator<OcenaDto>
    {
        public CreateOcenaValidator(Context context)
        {
            RuleFor(x => x.Vrednost)
                .NotEmpty().WithMessage("Ocena je obavezna")
                .GreaterThan(0).WithMessage("Ocena mora biti veca od 0")
                .LessThanOrEqualTo(10).WithMessage("Ocena mora biti manja od 10"); ;
            RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x)).WithMessage("Korisnik ne postoji u bazi");
            RuleFor(x => x.PostId).Must(x => context.Posts.Any(y => y.Id == x)).WithMessage("Post ne postoji u bazi");
        }
    }
}
