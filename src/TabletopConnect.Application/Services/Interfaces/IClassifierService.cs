using TabletopConnect.Application.Services.Validation;
using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Application.Services.Interfaces;

public interface IClassifierService<TClassifier>
    where TClassifier : BaseClassifier<int>
{
    Task<List<TClassifier>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<List<TClassifier>> GetAllReadonlyAsync(CancellationToken cancellationToken = default);

    Task<ValidationResultDto> CreateAsync(string name, CancellationToken cancellationToken = default);
    
    Task<ValidationResultDto> UpdateAsync(int id, string name, CancellationToken cancellationToken = default);

    Task<ValidationResultDto> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
