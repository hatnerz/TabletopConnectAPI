namespace TabletopConnect.Domain.Entities.Common;

public class SoftEntity<Tkey> : Entity<Tkey>
{
    public bool IsDeleted { get; private set; }

    public bool SoftDelete()
    {
        if (IsDeleted)
        {
            return false;
        }

        IsDeleted = true;
        return true;
    }
}
