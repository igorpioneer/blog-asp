using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.DTO;
using EfDataAccess;
using Domain;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly Context _context;
        private readonly CreateCategoryValidator _validator;

        public EfCreateCategoryCommand(Context context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create new category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };

            _context.Add(category);
            _context.SaveChanges();
        }
    }
}
