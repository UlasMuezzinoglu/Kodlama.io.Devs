using Application.Features.Developer.Commands.LoginCommand;
using Application.Features.Developer.Commands.RegisterCommand;
using Application.Features.Developer.Dtos;
using AutoMapper;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developer.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DeveloperEntity, RegisterCommand>().ReverseMap();
            CreateMap<DeveloperEntity, LoginCommand>().ReverseMap();
            CreateMap<AccessTokenDto, AccessToken>().ReverseMap();
        }
    }
}
