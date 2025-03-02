using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate;

namespace TabletopConnect.Application.Services.Recommendations;

public class BoardGamesRecommendationsService
{
    private readonly List<BoardGame> _games;
    private readonly HashSet<int> _allCategories;
    private readonly HashSet<int> _allMechanics;
    private readonly HashSet<int> _allThemes;
    private readonly HashSet<int> _allSubcategories;

    public BoardGamesRecommendationsService(List<BoardGame> games)
    {
        _games = games;
        _allCategories = new HashSet<int>(_games.SelectMany(g => g.BoardGameCategories.Select(e => e.CategoryId)).Distinct());
        _allMechanics = new HashSet<int>(_games.SelectMany(g => g.BoardGameMechanics.Select(e => e.MechanicsId)).Distinct());
        _allThemes = new HashSet<int>(_games.SelectMany(g => g.BoardGameThemes.Select(e => e.ThemeId)).Distinct());
        _allSubcategories = new HashSet<int>(_games.SelectMany(g => g.BoardGameSubcategories.Select(e => e.SubcategoryId)).Distinct());
    }

    /// <summary>
    /// Рекомендует игры на основе любимых игр пользователя
    /// </summary>
    public List<BoardGame> RecommendGames(List<int> favoriteGameIds, int topN = 10)
    {
        // Получаем любимые игры
        var favoriteGames = _games.Where(g => favoriteGameIds.Contains(g.Id)).ToList();
        if (!favoriteGames.Any()) return [];

        // Вектор предпочтений пользователя (средний вектор любимых игр)
        var userVector = AverageVector(favoriteGames);

        // Вычисляем сходство с остальными играми
        var recommendations = _games
            .Select(g => new { Game = g, Similarity = CosineSimilarity(userVector, GameToVector(g)) })
            .Where(x => !favoriteGameIds.Contains(x.Game.Id)) // Исключаем уже любимые игры
            .OrderByDescending(x => x.Similarity)
            .Take(topN)
            .Select(x => x.Game)
            .ToList();

        return recommendations;
    }

    /// <summary>
    /// Преобразование игры в числовой вектор
    /// </summary>
    private Vector<double> GameToVector(BoardGame game)
    {
        var vector = new List<double>();

        // One-Hot Encoding категорий
        vector.AddRange(_allCategories.Select(cat => game.BoardGameCategories.Any(bgc => bgc.CategoryId == cat) ? 1.0 : 0.0));
        vector.AddRange(_allMechanics.Select(mec => game.BoardGameMechanics.Any(bgm => bgm.MechanicsId == mec) ? 1.0 : 0.0));
        vector.AddRange(_allThemes.Select(theme => game.BoardGameThemes.Any(bgt => bgt.ThemeId == theme) ? 1.0 : 0.0));
        vector.AddRange(_allSubcategories.Select(subcategory => game.BoardGameSubcategories.Any(bgs => bgs.SubcategoryId == subcategory) ? 1.0 : 0.0));

        // Числовые параметры (нормализуем от 0 до 1)
        vector.Add(Normalize(game.YearPublished, 1900, 2025));
        vector.Add(Normalize(game.GameComplexity, 1, 5));
        vector.Add(Normalize(game.BggData!.BggScore, 0, 10));
        vector.Add(Normalize(game.Players!.MinPlayers, 1, 20));
        vector.Add(Normalize(game.Players.MaxPlayers, 1, 20));

        return DenseVector.OfArray(vector.ToArray());
    }

    /// <summary>
    /// Средний вектор по любимым играм пользователя
    /// </summary>
    private Vector<double> AverageVector(List<BoardGame> games)
    {
        var vectors = games.Select(GameToVector).ToList();
        return vectors.Aggregate((v1, v2) => v1 + v2) / games.Count;
    }

    /// <summary>
    /// Косинусное сходство между двумя векторами
    /// </summary>
    private double CosineSimilarity(Vector<double> v1, Vector<double> v2)
    {
        return v1.DotProduct(v2) / (v1.L2Norm() * v2.L2Norm());
    }

    /// <summary>
    /// Нормализация значения в диапазоне [0,1]
    /// </summary>
    private double Normalize(double value, double min, double max)
    {
        return (value - min) / (max - min);
    }
}
