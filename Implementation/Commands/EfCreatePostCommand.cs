using Application.Commands;
using Application.DTO;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private readonly Context _context;
        private readonly CreatePostValidator _validator;

        public EfCreatePostCommand(Context context, CreatePostValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "New Post Create";

        public void Execute(PostDto request)
        {
            _validator.ValidateAndThrow(request);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

            var post = new Post
            {
                Title = request.Title,
                Body = request.Body,
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                Slika = newFileName
            };

            _context.Add(post);
            _context.SaveChanges();
        }
    }
}
