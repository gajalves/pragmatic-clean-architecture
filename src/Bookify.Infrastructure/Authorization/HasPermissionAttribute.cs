using Microsoft.AspNetCore.Authorization;

namespace Bookify.Infrastructure.Authorization;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission) : base(permission)
    {
        
    }
}
