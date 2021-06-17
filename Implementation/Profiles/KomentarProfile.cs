using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Implementation.Profiles
{
    class KomentarProfile : Profile
    {
        public KomentarProfile()
        {
            CreateMap<Komentar, KomentarDto>();
        }
    }
}
