using Bookify.Domain.Users.ValueObjects;

namespace Bookify.Domain.UnitTests.Users;

internal static class UserData
{
    public static readonly FirstName firstName = new("First");
    public static readonly LastName lastName = new("Last");
    public static readonly Email email = new("test@test.com");
}
