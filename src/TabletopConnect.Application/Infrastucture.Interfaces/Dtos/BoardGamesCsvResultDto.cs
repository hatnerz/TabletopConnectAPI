using TabletopConnect.Infrastructure.DataImporters.Dtos;

namespace TabletopConnect.Application.Infrastucture.Interfaces.Dtos;

public record BoardGamesCsvResultDto(
    List<BoardGameCsvReturnDto> BoardGames,
    List<ClassifierCsvReturnDto> Families,
    List<ClassifierCsvReturnDto> Categories,
    List<BoardGameClassifierRelationCsvReturnDto> BoardGameCategories);
