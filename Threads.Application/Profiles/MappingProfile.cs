using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.DTOs.User;
using Threads.Domain.Entities;

namespace Threads.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile ( )
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
        }
    }
}
