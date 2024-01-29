using Bookify.Domain.Apartments;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    //public Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    //{
    //    throw new NotImplementedException();
    //}
}
