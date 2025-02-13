using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class Theme : BaseClassifier<int>
{
    public Theme(string name) : base(name)
    {
    }
}
