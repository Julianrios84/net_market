using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.CategoryName, x => x.MapFrom(a => a.Category.Name))
                .ForMember(p => p.MarkName, x => x.MapFrom(a => a.Mark.Name));

        }
    }
}
