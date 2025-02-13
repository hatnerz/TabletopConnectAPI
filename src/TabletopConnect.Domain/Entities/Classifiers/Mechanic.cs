using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Mechanic : BaseClassifier<int>
{
    public Mechanic(string name) : base(name)
    {
    }
}
