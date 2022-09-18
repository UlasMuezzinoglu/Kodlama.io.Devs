using Application.Features.programmingLanguage.addProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.programmingLanguage.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageEntity, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, CreateProgrammingLanguageCommand>().ReverseMap();

        }
    }
}
