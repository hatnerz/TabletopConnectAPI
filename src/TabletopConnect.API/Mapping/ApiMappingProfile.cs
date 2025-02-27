using AutoMapper;
using TabletopConnect.API.Controllers.Dtos.Auth;
using TabletopConnect.API.Controllers.Dtos.Classifiers;
using TabletopConnect.Application.Services.Dtos.Users;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.API.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<AuthRequest, AuthDto>();
        CreateMap<LinkGoogleRequest, LinkGoogleDto>();

        CreateMap<Category, ClassifierItemResponse>();
        CreateMap<Designer, ClassifierItemResponse>();
        CreateMap<Family, ClassifierItemResponse>();
        CreateMap<Mechanics, ClassifierItemResponse>();
        CreateMap<Publisher, ClassifierItemResponse>();
        CreateMap<Subcategory, ClassifierItemResponse>();
        CreateMap<Theme, ClassifierItemResponse>();
    }
}
