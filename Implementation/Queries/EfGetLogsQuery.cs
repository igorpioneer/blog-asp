using Application;
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


namespace Implementation.Queries
{
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly Context context;
        private readonly IMapper _mapper;

        public EfGetLogsQuery(Context context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Prikaz i pretraga logova";

        public PagedResponse<LogoviDto> Execute(LogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            return query.Paged<LogoviDto, UseCaseLog>(search, _mapper);
        }
    }
}
