namespace Bookify.Domain.Reviews;

public record ReviewId(Guid Value)
{
    public static ReviewId New() => new(Guid.NewGuid());
}