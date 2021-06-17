using Application.DTO;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<KomentarDto>
    {
        public CreateCommentValidator(Context context)
        {
            RuleFor(x => x.Vrednost)
                .NotEmpty()
                .WithMessage("Polje komentara je prazno");

            RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x)).WithMessage("Korisnik ne postoji!");
            RuleFor(x => x.PostId).Must(x => context.Posts.Any(y => y.Id == x)).WithMessage("Post ne postoji!");
        }
    }
}
