using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Publisher : BaseClassifier<int>
{
    public Publisher(string name) : base(name)
    {
    }
}
