namespace TabletopConnect.Domain.Entities.Common;

public class AuditInfo
{
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void UpdateAuditData(bool created)
    {
        if (created)
        {
            CreatedAt = DateTime.UtcNow;
        }

        UpdatedAt = DateTime.UtcNow;
    }
}
