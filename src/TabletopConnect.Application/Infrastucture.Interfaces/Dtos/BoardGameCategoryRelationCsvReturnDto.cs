namespace TabletopConnect.Application.Infrastucture.Interfaces.Dtos;

public record BoardGameCategoryRelationCsvReturnDto(
    int BggId,
    string BoardGameCategoryName,
    int Rank);
