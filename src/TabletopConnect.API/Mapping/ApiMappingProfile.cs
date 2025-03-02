using AutoMapper;
using TabletopConnect.API.Controllers.Dtos.Auth;
using TabletopConnect.API.Controllers.Dtos.BoardGames;
using TabletopConnect.API.Controllers.Dtos.Classifiers;
using TabletopConnect.API.Extensions;
using TabletopConnect.Application.Persistence.Interfaces.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.BoardGames;
using TabletopConnect.Application.Services.Dtos.Classifiers;
using TabletopConnect.Application.Services.Dtos.Users;
using TabletopConnect.Domain.Entities.Classifiers;

namespace TabletopConnect.API.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<AuthRequest, AuthDto>();

        CreateMap<Category, ClassifierItemResponse>();
        CreateMap<Designer, ClassifierItemResponse>();
        CreateMap<Family, ClassifierItemResponse>();
        CreateMap<Mechanics, ClassifierItemResponse>();
        CreateMap<Publisher, ClassifierItemResponse>();
        CreateMap<Subcategory, ClassifierItemResponse>();
        CreateMap<Theme, ClassifierItemResponse>();
        CreateMap<ClassifierReturnDto, ClassifierItemResponse>();

        CreateMap<BoardGamesFilterRequest, BoardGamesFilterDto>();
        CreateMap<BoardGamesPaginationRequest, BoardGamesPaginationDto>()
            .ForMember(dto => dto.Sorting, opt => opt.MapFrom(r => r.Sorting == null ? null : r.Sorting.TransformToList()));

        CreateMap<BoardGameSummaryReturnDto, BoardGameSummaryResponse>();
        CreateMap<BoardGamesPaginationReturnDto, BoardGamesPaginationResponse>();

        CreateMap<CategoryWithPositionReturnDto, CategoryWithPositionResponse>();
        CreateMap<BoardGameReturnDto, BoardGameResponse>();
        CreateMap<BoardGameDetailsReturnDto, BoardGameDetailsResponse>();
    }
}
