using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.Common;

public abstract class BaseClassifier<TKey> : SoftEntity<TKey>
    where TKey : struct
{
    public string Name { get; private set; } = null!;

    private BaseClassifier()
    {
    }

    protected BaseClassifier(string name)
    {
        TextValidators.ValidateRequiredTextProperty(name, 300, nameof(Name));
        Name = name;
    }

    public void Update(string name)
    {
        TextValidators.ValidateRequiredTextProperty(name, 300, nameof(Name));
        Name = name;
    }
}
