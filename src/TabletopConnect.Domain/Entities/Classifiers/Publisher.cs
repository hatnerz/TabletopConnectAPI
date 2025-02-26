using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Publisher : BaseClassifier<int>
{
    private Publisher()
    {
    }

    public Publisher(string name) : base(name)
    {
    }
}
