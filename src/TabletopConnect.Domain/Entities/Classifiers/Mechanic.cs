using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Mechanic : BaseClassifier<int>
{
    private Mechanic()
    {
    }

    public Mechanic(string name) : base(name)
    {
    }
}
