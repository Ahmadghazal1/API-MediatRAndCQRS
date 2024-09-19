using AutoMapper;
using Core.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
           CreateMap<Category,AllCategoryResponseDto>().ReverseMap();
           CreateMap<Category,CategoryRequestDto>().ReverseMap();
        }
    }
}
