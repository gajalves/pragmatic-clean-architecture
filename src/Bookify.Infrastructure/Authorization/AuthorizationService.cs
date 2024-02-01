using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Authorization;

internal sealed class AuthorizationService
{
    private readonly ApplicationDbContext _context;

    public AuthorizationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserRolesResponse> GetRolesForUserAsync(string IdentityId)
    {
        var roles = await _context.Set<User>()
            .Where(user => user.IdentityId == IdentityId)
            .Select(user => new UserRolesResponse
            {
                Id = user.Id,
                Roles = user.Roles.ToList()
            })
            .FirstAsync();

        return roles; 
    }

    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {        
        var permissions = await _context.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .SelectMany(user => user.Roles.Select(role => role.RolePermissions))
            .Select(r => r.Permission)
            .ToListAsync();

        var permissionsSet = permissions.Select(p => p.Name).ToHashSet();

        return permissionsSet;
    }
}
