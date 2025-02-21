using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Subcategory : BaseClassifier<int>
{
    public Subcategory(string name) : base(name)
    {
    }
}
