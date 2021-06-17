using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly Context _context;

        public EfDeleteCommentCommand(Context context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Brisanje komentara ";

        public void Execute(KomentarDto request)
        {
            var comm = _context.Komentars.Find(request.Id);

            if (comm == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Komentar));
            }

            _context.Komentars.Remove(comm);

            _context.SaveChanges();
        }
    }
}
