using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Category : BaseDictionary<int>
{
    public Category(string name) : base(name)
    {
    }
}
