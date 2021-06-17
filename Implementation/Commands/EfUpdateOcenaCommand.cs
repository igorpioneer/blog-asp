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
    public class EfUpdateOcenaCommand : IUpdateOcenaCommand
    {
        private readonly Context _context;
        private readonly CreateOcenaValidator _validator;

        public EfUpdateOcenaCommand(Context context, CreateOcenaValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Izmena ocene";

        public void Execute(OcenaDto request)
        {
            _validator.ValidateAndThrow(request);

            var ocena = _context.Ocenas.Find(request.Id);

            if (ocena == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Ocena));
            }

            ocena.Vrednost = request.Vrednost;
            ocena.UserId = request.UserId;
            ocena.PostId = request.PostId;
            _context.Ocenas.Update(ocena);
            _context.SaveChanges();
        }
    }
}
