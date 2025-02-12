using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class GameFamily : BaseDictionary<int>
{
    public GameFamily(string name) : base(name)
    {
    }
}
