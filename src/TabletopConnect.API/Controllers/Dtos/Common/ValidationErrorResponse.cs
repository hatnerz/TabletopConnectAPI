using TabletopConnect.Application.Services.Validation;

namespace TabletopConnect.API.Controllers.Dtos.Common;

public record ValidationErrorResponse(
    IEnumerable<ValidationErrorDto> validationErrors);
