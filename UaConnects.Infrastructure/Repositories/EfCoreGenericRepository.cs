using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UaConnects.Domain.Entities;
using UaConnects.Domain.Repository.Interfaces;

namespace UaConnects.Infrastructure.Repositories
{
    class EfCoreGenericRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public EfCoreGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<TEntity> InsertOneAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            _context.Update(item);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
