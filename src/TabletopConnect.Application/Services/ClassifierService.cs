using System.Xml.Linq;
using TabletopConnect.Application.Persistence.Interfaces;
using TabletopConnect.Application.Services.Interfaces;
using TabletopConnect.Application.Services.Validation;
using TabletopConnect.Common.Constants;
using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Application.Services;

public abstract class ClassifierService<TClassifier> : IClassifierService<TClassifier>
    where TClassifier : BaseClassifier<int>
{
    protected readonly IClassifiersRepository<TClassifier, int> _repository;
    protected readonly IUnitOfWork _unitOfWork;

    protected ClassifierService(IClassifiersRepository<TClassifier, int> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TClassifier>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public async Task<List<TClassifier>> GetAllReadonlyAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllReadonlyAsync(cancellationToken);
    }

    public async Task<ValidationResult> CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _repository.GetByNameAsync(name, cancellationToken);
        if (existingEntity is not null)
        {
            var error = new ValidationError(ValidationMessages.Common.EntityAlreadyExists(typeof(TClassifier).Name, nameof(name)));
            return ValidationResult.CreateFailure([error]);
        }

        TClassifier? entity;
        entity = (TClassifier?)Activator.CreateInstance(typeof(TClassifier), name);

        if (entity is null)
        {
            var error  = new ValidationError(ValidationMessages.Common.EntityCreationFailture(typeof(TClassifier).Name));
            return ValidationResult.CreateFailure([error]);
        }

        _repository.Add(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ValidationResult.CreateSuccess();
    }

    public async Task<ValidationResult> UpdateAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _repository.GetByIdAsync(id, cancellationToken);

        if (existingEntity is null)
        {
            var error = new ValidationError(ValidationMessages.Common.EntityNotExists(typeof(TClassifier).Name, nameof(id)));
            return ValidationResult.CreateFailure([error]);
        }

        existingEntity.Update(name);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ValidationResult.CreateSuccess();
    }

    public async Task<ValidationResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _repository.GetByIdAsync(id, cancellationToken);

        if (existingEntity is null)
        {
            var error = new ValidationError(ValidationMessages.Common.EntityNotExists(typeof(TClassifier).Name, nameof(id)));
            return ValidationResult.CreateFailure([error]);
        }

        _repository.Remove(existingEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ValidationResult.CreateSuccess();
    }
}
