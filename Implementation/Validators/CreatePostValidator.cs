using Application.DTO;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreatePostValidator : AbstractValidator<PostDto>
    {
        public CreatePostValidator(Context context)
        {
            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage("Text body is required");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .Must(body => !context.Posts.Any(p => p.Title == body))
                .WithMessage("That quote already exist");

            RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x)).WithMessage("User doesn't exist");
            RuleFor(x => x.CategoryId).Must(x => context.Categories.Any(y => y.Id == x)).WithMessage("Category doesn't exist");
        }
    }
}
