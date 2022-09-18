using Application.Features.programmingLanguage.addProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Models;
using Application.Features.programmingLanguage.Queries.GetProgrammingLanguageById;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.programmingLanguage.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageEntity, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageEntity, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, DeleteProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageEntity, UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageEntity, GetProgrammingLanguageByIdDto>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, GetProgrammingLanguageByIdQuery>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguageEntity>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguageEntity, ProgrammingLanguageListDto>().ReverseMap();
        }
    }
}
