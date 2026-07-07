using Atya.Foundation.Time;

namespace Time.Samples.Console;

/// <summary>
/// Runs the Atya.Foundation.Time console sample.
/// </summary>
public static class Program
{
    /// <summary>
    /// Demonstrates UTC clock and guard usage.
    /// </summary>
    public static void Main()
    {
        System.Console.WriteLine("Atya.Foundation.Time sample");

        SystemClock clock = new();
        DateTime utcNow = clock.UtcNow;
        DateTimeOffset utcNowOffset = clock.UtcNowOffset;
        DateOnly todayUtc = clock.TodayUtc;

        ScheduledJob job = new(
            "nightly-sync",
            TimeGuard.AgainstNonUtc(utcNow.AddHours(1)));

        System.Console.WriteLine($"UTC now: {utcNow:O}");
        System.Console.WriteLine($"UTC offset now: {utcNowOffset:O}");
        System.Console.WriteLine($"UTC date: {todayUtc:yyyy-MM-dd}");
        System.Console.WriteLine($"Scheduled '{job.Name}' for {job.RunAtUtc:O}");
    }
}

/// <summary>
/// Represents a sample job scheduled for a UTC timestamp.
/// </summary>
public sealed class ScheduledJob
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScheduledJob"/> class.
    /// </summary>
    /// <param name="name">The job name.</param>
    /// <param name="runAtUtc">The UTC run timestamp.</param>
    public ScheduledJob(string name, DateTime runAtUtc)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
        RunAtUtc = TimeGuard.AgainstNonUtc(runAtUtc);
    }

    /// <summary>
    /// Gets the job name.
    /// </summary>
    public string Name
    {
        get;
    }

    /// <summary>
    /// Gets the UTC run timestamp.
    /// </summary>
    public DateTime RunAtUtc
    {
        get;
    }
}
