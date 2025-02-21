namespace TabletopConnect.Application.Infrastucture.Interfaces.Dtos;

public record BoardGameClassifierRelationCsvReturnDto(
    int BggId,
    string RelatedEntityName);