using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Mechanic : BaseDictionary<int>
{
    public Mechanic(string name) : base(name)
    {
    }
}
