using Atya.Foundation.Time;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Time.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        _ = args;
        BenchmarkRunner.Run<ClockBenchmarks>();
    }
}

[MemoryDiagnoser]
[ShortRunJob]
public class ClockBenchmarks
{
    private readonly SystemClock _clock = new();
    private readonly DateTime _utcDateTime = new(2026, 1, 1, 12, 30, 0, DateTimeKind.Utc);
    private readonly DateTimeOffset _utcDateTimeOffset = new(2026, 1, 1, 12, 30, 0, TimeSpan.Zero);

    [Benchmark]
    public DateTime ReadUtcNow()
    {
        return _clock.UtcNow;
    }

    [Benchmark]
    public DateTimeOffset ReadUtcNowOffset()
    {
        return _clock.UtcNowOffset;
    }

    [Benchmark]
    public DateOnly ReadTodayUtc()
    {
        return _clock.TodayUtc;
    }

    [Benchmark]
    public DateTime ValidateUtcDateTime()
    {
        return TimeGuard.AgainstNonUtc(_utcDateTime);
    }

    [Benchmark]
    public DateTimeOffset ValidateUtcDateTimeOffset()
    {
        return TimeGuard.AgainstNonUtc(_utcDateTimeOffset);
    }
}
