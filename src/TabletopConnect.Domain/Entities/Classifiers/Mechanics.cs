using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Mechanics : BaseClassifier<int>
{
    private Mechanics()
    {
    }

    public Mechanics(string name) : base(name)
    {
    }
}
