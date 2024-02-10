namespace Bookify.Infrastructure.Outbox;

public sealed class OutboxOptions
{
    public int IntervalInSeconds { get; set; }
    public int BatchSize { get; set; }
}
