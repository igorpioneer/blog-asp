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
    public class EfDeleteOcenaCommand : IDeleteOcenaCommand
    {
        private readonly Context _context;

        public EfDeleteOcenaCommand(Context context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Brisanje ocene";

        public void Execute(OcenaDto request)
        {
            var ocena = _context.Ocenas.Find(request.Id);

            if (ocena == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Ocena));
            }

            _context.Ocenas.Remove(ocena);

            _context.SaveChanges();
        }
    }
}
