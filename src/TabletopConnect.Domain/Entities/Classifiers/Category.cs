using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Category : BaseClassifier<int>
{
    public Category(string name) : base(name)
    {
    }
}
