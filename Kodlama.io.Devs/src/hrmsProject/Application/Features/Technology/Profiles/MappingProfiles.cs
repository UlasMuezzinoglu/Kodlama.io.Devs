using Application.Features.programmingLanguage.addProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Models;
using Application.Features.programmingLanguage.Queries.GetProgrammingLanguageById;
using Application.Features.Technology.Commands.CreateTechnology;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Commands.UpdateTechnology;
using Application.Features.Technology.Dtos;
using Application.Features.Technology.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TechnologyEntity, CreatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<TechnologyEntity, CreateTechnologyCommand>().ReverseMap();

            CreateMap<TechnologyEntity, DeletedTechnologyDto>().ReverseMap();
            CreateMap<TechnologyEntity, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<TechnologyEntity, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<TechnologyEntity, UpdateTechnologyCommand>().ReverseMap();




            CreateMap<TechnologyEntity, TechnologyListDto>()
                .ForMember(c => c.ProgrammingName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();

            CreateMap<IPaginate<TechnologyEntity>, TechnologyListModel>().ReverseMap();

        }
    }
}
