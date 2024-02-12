using Bookify.Domain.Users;
using Bookify.Domain.Users.ValueObjects;

namespace Bookify.Application.UnitTests.Users;

internal static class UserData
{
    public static readonly FirstName firstName = new("First");
    public static readonly LastName lastName = new("Last");
    public static readonly Email email = new("test@test.com");

    public static User Create() => User.Create(firstName, lastName, email);

}
