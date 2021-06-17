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
    public class EfUpdatePostCommand : IUpdatePostCommand
    {
        private readonly Context _context;
        private readonly CreatePostValidator _validator;

        public EfUpdatePostCommand(Context context, CreatePostValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Update Post";

        public void Execute(PostDto request)
        {
            _validator.ValidateAndThrow(request);

            var post = _context.Posts.Find(request.Id);

            if (post == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Post));
            }

            post.Body = request.Body;
            post.UserId = request.UserId;
            post.CategoryId = request.CategoryId;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
