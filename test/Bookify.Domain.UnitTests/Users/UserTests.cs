using Bookify.Domain.Users;
using Bookify.Domain.Users.Events;
using FluentAssertions;

namespace Bookify.Domain.UnitTests.Users;

public class UserTests
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        // Act
        var user = User.Create(UserData.firstName, UserData.lastName, UserData.email);

        // Assert
        user.FirstName.Should().Be(UserData.firstName);
        user.LastName.Should().Be(UserData.lastName);
        user.Email.Should().Be(UserData.email);
    }

    [Fact]
    public void Create_Should_RaiseUserCreatedDomainEvent()
    {
        // Act
        var user = User.Create(UserData.firstName, UserData.lastName, UserData.email);

        // Assert
        var domainEvent = user.GetDomainEvents().OfType<UserCreatedDomainEvent>().SingleOrDefault();
        domainEvent.UserId.Should().Be(user.Id);
    }

    [Fact]
    public void Create_Should_AddRegisteredRoleToUser()
    {
        // Act
        var user = User.Create(UserData.firstName, UserData.lastName, UserData.email);

        // Assert
        user.Roles.Should().Contain(Role.Registered);
    }
}
