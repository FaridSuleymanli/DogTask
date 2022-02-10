using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Entities.DTOs;
using TestTask.Entities.Models;

namespace TestTask.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dog, DogsForGetDTO>().ReverseMap();
            CreateMap<DogsForCreateDTO, Dog>().ReverseMap();
        }
    }
}
