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
    public class EfGetQCommentQuery : IGetCommentQuery
    {
        private readonly Context context;
        private readonly IMapper _mapper;

        public EfGetQCommentQuery(Context context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Komentar get";

        public PagedResponse<KomentarDto> Execute(KomentarSearch search)
        {
            var query = context.Komentars.AsQueryable();

            if (!string.IsNullOrEmpty(search.Vrednost) || !string.IsNullOrWhiteSpace(search.Vrednost))
            {
                query = query.Where(x => x.Vrednost.ToLower().Contains(search.Vrednost.ToLower()));
            }

            return query.Paged<KomentarDto, Komentar>(search, _mapper);
        }
    }
}
