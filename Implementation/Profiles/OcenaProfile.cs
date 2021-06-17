using Application.DTO;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    class OcenaProfile : Profile
    {
        public OcenaProfile()
        {
            CreateMap<Ocena, OcenaDto>();
        }
    }
}
