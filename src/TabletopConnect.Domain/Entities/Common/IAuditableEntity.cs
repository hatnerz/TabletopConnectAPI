namespace TabletopConnect.Domain.Entities.Common;
public interface IAuditableEntity
{
    AuditInfo Audit { get; }
}
