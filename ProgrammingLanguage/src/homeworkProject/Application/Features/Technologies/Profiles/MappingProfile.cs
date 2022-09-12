using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ForMember(p => p.ProgrammingLanguageName, p => p.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();
        }
    }
}
