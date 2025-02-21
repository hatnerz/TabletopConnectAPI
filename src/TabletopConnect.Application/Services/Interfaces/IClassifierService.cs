using TabletopConnect.Application.Services.Validation;
using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Application.Services.Interfaces;

public interface IClassifierService<TClassifier>
    where TClassifier : BaseClassifier<int>
{
    Task<List<TClassifier>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<List<TClassifier>> GetAllReadonlyAsync(CancellationToken cancellationToken = default);

    Task<ValidationResult> CreateAsync(string name, CancellationToken cancellationToken = default);
    
    Task<ValidationResult> UpdateAsync(int id, string name, CancellationToken cancellationToken = default);

    Task<ValidationResult> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
