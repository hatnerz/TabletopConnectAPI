namespace TabletopConnect.API.Controllers.Dtos.Classifiers;

public record UpdateClassifierRequest(
    int Id,
    string Name);