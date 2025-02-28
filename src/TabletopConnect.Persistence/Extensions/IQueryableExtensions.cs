using System.Linq.Expressions;
using TabletopConnect.Common.Enums;

namespace TabletopConnect.Persistence.Extensions;

internal static class IQueryableExtensions
{
    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, List<(string fieldName, SortingDirection direction)> sorting)
    {
        foreach (var (field, direction) in sorting)
        {
            query = ApplySorting(query, field, direction);
        }

        return query;
    }

    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string fieldName, SortingDirection sorting)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, fieldName);
        var lambda = Expression.Lambda(property, parameter);

        string methodName = sorting == SortingDirection.Asc ? "OrderBy" : "OrderByDescending";
        var method = typeof(Queryable).GetMethods()
            .First(m => m.Name == methodName && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), property.Type);

        return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda })!;
    }
}
