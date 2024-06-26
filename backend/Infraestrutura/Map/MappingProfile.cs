using AutoMapper;
using backend.Dtos;
using backend.models;

namespace backend.Infraestrutura.Map;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Posto, PostoDtoRequest>().ReverseMap();
        
        CreateMap<VacinaDtoRequest, Vacina>()
            .ForMember(dest => dest.PostoId, opt => opt.MapFrom(src => src.PostoID))
            .ForMember(dest => dest.Posto, opt => opt.Ignore()); 
    }

}
