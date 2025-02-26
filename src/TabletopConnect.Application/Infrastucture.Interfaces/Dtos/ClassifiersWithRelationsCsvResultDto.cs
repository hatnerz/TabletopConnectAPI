using TabletopConnect.Infrastructure.DataImporters.Dtos;

namespace TabletopConnect.Application.Infrastucture.Interfaces.Dtos;

public record ClassifiersWithRelationsCsvResultDto(
    List<ClassifierCsvReturnDto> Classifiers,
    List<BoardGameClassifierRelationCsvReturnDto> BoardGameWithClassfierRelations);
