using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Designer : BaseClassifier<int>
{
    private Designer()
    {
    }

    public Designer(string name) : base(name)
    {
    }
}
