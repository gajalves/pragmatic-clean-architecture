using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository : BaseRepository<User, UserId>, IUserRepository
{
    
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
