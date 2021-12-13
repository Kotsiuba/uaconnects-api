using System;
using System.Threading;
using System.Threading.Tasks;
using UaConnects.Domain.Entities;

namespace UaConnects.Domain.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> InsertOneAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
    }
}
