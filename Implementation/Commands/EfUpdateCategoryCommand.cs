using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly Context _context;
        private readonly CreateCategoryValidator _validator;

        public EfUpdateCategoryCommand(Context context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 5;

        public string Name => "Update category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = _context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            category.Name = request.Name;
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

    }
}
