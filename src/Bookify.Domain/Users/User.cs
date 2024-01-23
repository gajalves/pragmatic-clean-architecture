using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.Events;
using Bookify.Domain.Users.ValueObjects;

namespace Bookify.Domain.Users;

public sealed class User : Entity<UserId>
{
    private User(UserId id, FirstName firstName, LastName lastName, Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public User()
    {
        
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(UserId.New(), firstName, lastName, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        
        return user;
    }
}
