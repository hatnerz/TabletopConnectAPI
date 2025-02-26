using AutoMapper;
using TabletopConnect.API.Controllers.Dtos.Auth;
using TabletopConnect.Application.Services.Dtos.Users;

namespace TabletopConnect.API.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<AuthRequest, AuthDto>();
        CreateMap<LinkGoogleRequest, LinkGoogleDto>();
    }
}
