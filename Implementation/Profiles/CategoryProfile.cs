using AutoMapper;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Domain.Category, CategoryDto>();
        }
    }
}
