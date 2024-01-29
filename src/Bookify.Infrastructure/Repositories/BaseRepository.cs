﻿using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories;

internal abstract class BaseRepository<T>
    where T : Entity    
{
    protected readonly ApplicationDbContext DbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }
}