using TabletopConnect.Common.Constants;
using TabletopConnect.Common.Enums;

namespace TabletopConnect.Application.Services.Dtos.Common;

public abstract class PaginationDto
{
    public List<(string FieldName, SortingDirection Sorting)>? Sorting { get; set; }
    public string? Search { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}