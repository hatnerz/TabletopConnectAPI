using TabletopConnect.Application.Infrastucture.Interfaces.Dtos;

namespace TabletopConnect.Application.Infrastucture.Interfaces;

public interface IBoardGamesCsvImportService
{
    BoardGamesCsvResultDto GetBoardGamesInitialImportData(Stream csvStream);
    //Task<BoardGamesCsvResultDto> GetMechanicsInitialImportDataAsync(Stream csvFileStream);
    //Task<BoardGamesCsvResultDto> GetSubcategoriesInitialImportDataAsync(Stream csvFileStream);
    //Task<BoardGamesCsvResultDto> GetThemesInitialImportDataAsync(Stream csvFileStream);
    //Task<BoardGamesCsvResultDto> GetDesignersInitialImportDataAsync(Stream csvFileStream);
}
