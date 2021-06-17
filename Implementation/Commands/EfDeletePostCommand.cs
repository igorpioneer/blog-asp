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
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private readonly Context _context;

        public EfDeletePostCommand(Context context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "Delete Post";

        public void Execute(PostDto request)
        {
            var post = _context.Posts.Find(request.Id);

            if (post == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Post));
            }

            _context.Posts.Remove(post);

            _context.SaveChanges();
        }
    }
}
