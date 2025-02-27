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

    public async Task<(ValidationResultDto, int)> CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        var existingEntityWithName = await _repository.GetByNameAsync(name, null, cancellationToken);
        if (existingEntityWithName is not null)
        {
            var error = new ValidationErrorDto(
                ValidationMessages.Common.EntityAlreadyExists(
                    typeof(TClassifier).Name,
                    nameof(name)),
                nameof(name));
            return (ValidationResultDto.CreateFailure([error]), -1);
        }

        TClassifier? entity;
        entity = (TClassifier?)Activator.CreateInstance(typeof(TClassifier), name);

        if (entity is null)
        {
            var error  = new ValidationErrorDto(ValidationMessages.Common.EntityCreationFailture(typeof(TClassifier).Name));
            return (ValidationResultDto.CreateFailure([error]), -1);
        }

        _repository.Add(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return (ValidationResultDto.CreateSuccess(), entity.Id);
    }

    public async Task<ValidationResultDto> UpdateAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        var existingEntityWithName = await _repository.GetByNameAsync(name, id, cancellationToken);
        if (existingEntityWithName is not null)
        {
            var error = new ValidationErrorDto(
                ValidationMessages.Common.EntityAlreadyExists(
                    typeof(TClassifier).Name,
                    nameof(name)),
                nameof(name));
            return ValidationResultDto.CreateFailure([error]);
        }

        var existingEntity = await _repository.GetByIdAsync(id, cancellationToken);

        if (existingEntity is null)
        {
            var error = new ValidationErrorDto(
                ValidationMessages.Common.EntityNotExists(
                    typeof(TClassifier).Name));
            return ValidationResultDto.CreateFailure([error]);
        }

        existingEntity.Update(name);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ValidationResultDto.CreateSuccess();
    }

    public async Task<ValidationResultDto> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _repository.GetByIdAsync(id, cancellationToken);

        if (existingEntity is null)
        {
            var error = new ValidationErrorDto(
                ValidationMessages.Common.EntityNotExists(
                    typeof(TClassifier).Name));
            return ValidationResultDto.CreateFailure([error]);
        }

        _repository.Remove(existingEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ValidationResultDto.CreateSuccess();
    }
}
