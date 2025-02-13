using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Dictionaries;

public class GameDesigner : BaseClassifier<int>
{
    public GameDesigner(string name) : base(name)
    {
    }
}
