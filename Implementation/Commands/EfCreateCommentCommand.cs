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
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly Context _context;
        private readonly CreateCommentValidator _validator;

        public EfCreateCommentCommand(Context context, CreateCommentValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Dodavaje komentara";

        public void Execute(KomentarDto request)
        {
            _validator.ValidateAndThrow(request);

            var comm = new Komentar
            {
                Vrednost = request.Vrednost,
                UserId = request.UserId,
                PostId = request.PostId
            };

            _context.Add(comm);
            _context.SaveChanges();
        }

        
    }
}
