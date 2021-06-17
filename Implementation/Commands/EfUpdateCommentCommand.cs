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
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly Context _context;
        private readonly CreateCommentValidator _validator;

        public EfUpdateCommentCommand(Context context, CreateCommentValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Editovanje komentara";

        public void Execute(KomentarDto request)
        {
            _validator.ValidateAndThrow(request);

            var komentar = _context.Komentars.Find(request.Id);

            if (komentar == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Komentar));
            }

            komentar.Vrednost = request.Vrednost;
            komentar.UserId = request.UserId;
            komentar.PostId = request.PostId;
            _context.Komentars.Update(komentar);
            _context.SaveChanges();
        }
    }
}
