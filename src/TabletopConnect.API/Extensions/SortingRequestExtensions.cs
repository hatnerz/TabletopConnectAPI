using System.Reflection;
using TabletopConnect.API.Mapping;
using TabletopConnect.Common.Enums;

namespace TabletopConnect.API.Extensions;

public static class SortingRequestExtensions
{
    public static List<(string, SortingDirection)> TransformToList(this ISortingRequest request)
    {
        return request.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType == typeof(SortingDirection))
            .Select(p => (p.Name, (SortingDirection)p.GetValue(request)!))
            .ToList();
    }
}
