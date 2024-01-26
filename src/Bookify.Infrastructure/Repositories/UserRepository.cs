using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository : BaseRepository<User, UserId>, IUserRepository
{
    
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }   
}
