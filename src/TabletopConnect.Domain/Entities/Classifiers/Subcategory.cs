using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Subcategory : BaseClassifier<int>
{
    private Subcategory()
    {
    }

    public Subcategory(string name) : base(name)
    {
    }
}
