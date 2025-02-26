using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Category : BaseClassifier<int>
{
    private Category()
    {
    }

    public Category(string name) : base(name)
    {
    }
}
