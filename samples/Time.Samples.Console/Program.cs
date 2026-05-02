using Atya.Foundation.Time;

namespace Time.Samples.Console;

public static class Program
{
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

public sealed class ScheduledJob
{
    public ScheduledJob(string name, DateTime runAtUtc)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
        RunAtUtc = TimeGuard.AgainstNonUtc(runAtUtc);
    }

    public string Name
    {
        get;
    }

    public DateTime RunAtUtc
    {
        get;
    }
}
