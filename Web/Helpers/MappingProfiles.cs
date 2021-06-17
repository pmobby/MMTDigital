using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.DTOs;
using Web.Core.Entities;

namespace Web.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.Category, o => o.MapFrom(s => s.Category.Name));
            CreateMap<Category, CategoryDTO>();
        }
    }
}
