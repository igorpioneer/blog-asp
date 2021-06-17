using Application.DTO;
using Application.Queries;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Implementation.Extensions;
using Domain;
using AutoMapper;

namespace Implementation.Queries
{
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly Context context;
        private readonly IMapper _mapper;

        public EfGetCategoryQuery(Context context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }
        public int Id => 3;

        public string Name => "Category search.";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<CategoryDto, Category>(search, _mapper);
           
        }
    }
}
