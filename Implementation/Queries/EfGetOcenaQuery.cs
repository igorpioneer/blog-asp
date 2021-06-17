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
    public class EfGetOcenaQuery : IGetOcenaQuery
    {
        private readonly Context context;
        private readonly IMapper _mapper;

        public EfGetOcenaQuery(Context context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Dohvatanje i search ocena";

        public PagedResponse<OcenaDto> Execute(OcenaSearch search)
        {
            var query = context.Ocenas.AsQueryable();

            var ocena = search.Vrednost;

            if (ocena > 0)
            {
                query = query.Where(x => x.Vrednost.Equals(search.Vrednost));
            }

            var userId = search.UserId;
            if (userId > 0)
            {
                query = query.Where(x => x.UserId.Equals(search.UserId));
            }

            var postId = search.PostId;
            if (postId > 0)
            {
                query = query.Where(x => x.PostId.Equals(search.PostId));
            }

            return query.Paged<OcenaDto, Ocena>(search, _mapper);
        }
    }
}
