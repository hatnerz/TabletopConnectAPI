using TabletopConnect.Application.Infrastucture.Interfaces.Dtos;

namespace TabletopConnect.Application.Infrastucture.Interfaces;

public interface IBoardGamesCsvImportService
{
    BoardGamesCsvResultDto GetBoardGamesImportedData(Stream csvStream);

    ClassifiersWithRelationsCsvResultDto GetClassifiersWithRelationsImportedDataDefault(Stream csvFileStream);

    ClassifiersWithRelationsCsvResultDto GetThemesImportedData(Stream csvFileStream);
    
}
