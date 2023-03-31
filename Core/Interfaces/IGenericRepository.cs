using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

// Usable by classes that derive from BaseEntity
// Only entities can be used with this Repository
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
}