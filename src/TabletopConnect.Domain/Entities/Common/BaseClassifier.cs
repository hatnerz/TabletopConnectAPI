namespace TabletopConnect.Domain.Entities.Common;

public abstract class BaseClassifier<TKey> : SoftEntity<TKey>
    where TKey : struct
{
    public string Name { get; private set; }

    protected BaseClassifier(string name)
    {
        Name = name;
    }
}
