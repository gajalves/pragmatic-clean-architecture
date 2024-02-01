namespace Bookify.Domain.Users;

public class RolePermission
{
    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public Role Role { get; set; }
    public Permission Permission { get; set; }
}
