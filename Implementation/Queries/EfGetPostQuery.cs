using Application.DTO;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain;
using EfDataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetPostQuery : IGetPostQuery
    {
        private readonly Context context;
        private readonly IMapper _mapper;

        public EfGetPostQuery(Context context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Get Posts";

        public PagedResponse<PostDto> Execute(PostSearch search)
        {
            var post = context.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(search.Body) || !string.IsNullOrWhiteSpace(search.Body))
            {
                post = post.Where(x => x.Body.ToLower().Contains(search.Body.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title))
            {
                post = post.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }

            return post.Paged<PostDto, Post>(search, _mapper);
        }
    }
}
