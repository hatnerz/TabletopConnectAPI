using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Theme : BaseClassifier<int>
{
    private Theme()
    {
    }

    public Theme(string name) : base(name)
    {
    }
}
