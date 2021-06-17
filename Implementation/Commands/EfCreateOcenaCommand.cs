using Application.Commands;
using Application.DTO;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateOcenaCommand : ICreateOcenaCommand
    {
        private readonly Context _context;
        private readonly CreateOcenaValidator _validator;

        public EfCreateOcenaCommand(Context context, CreateOcenaValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Ocenjivanje postova";

        public void Execute(OcenaDto request)
        {
            _validator.ValidateAndThrow(request);

            var ocena = new Ocena
            {
                Vrednost = request.Vrednost,
                UserId = request.UserId,
                PostId = request.PostId
            };

            _context.Add(ocena);
            _context.SaveChanges();
        }
    }
}
