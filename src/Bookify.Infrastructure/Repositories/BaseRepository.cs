using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories;

internal abstract class BaseRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    protected readonly ApplicationDbContext DbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(
        TEntityId id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }
}