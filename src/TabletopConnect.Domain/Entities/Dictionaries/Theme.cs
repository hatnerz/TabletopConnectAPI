using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Theme : BaseDictionary<int>
{
    public Theme(string name) : base(name)
    {
    }
}
