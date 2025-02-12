namespace TabletopConnect.Domain.Entities.Common;

public abstract class BaseDictionary<TKey> : SoftEntity<TKey>
    where TKey : struct
{
    public string Name { get; private set; }

    protected BaseDictionary(string name)
    {
        Name = name;
    }
}
