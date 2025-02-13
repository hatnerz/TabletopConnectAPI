using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Subcategory : BaseClassifier<int>
{
    public Subcategory(string name) : base(name)
    {
    }
}
