using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Publisher : BaseClassifier<int>
{
    public Publisher(string name) : base(name)
    {
    }
}
