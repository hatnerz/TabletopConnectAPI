using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Category : BaseClassifier<int>
{
    public Category(string name) : base(name)
    {
    }
}
