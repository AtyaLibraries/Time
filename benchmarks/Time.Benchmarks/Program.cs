using Atya.Foundation.Time;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Time.Benchmarks;

/// <summary>
/// Runs the Atya.Foundation.Time benchmark suite.
/// </summary>
public static class Program
{
    /// <summary>
    /// Executes the benchmark suite.
    /// </summary>
    /// <param name="args">Command-line arguments passed to BenchmarkDotNet.</param>
    public static void Main(string[] args)
    {
        _ = args;
        BenchmarkRunner.Run<ClockBenchmarks>();
    }
}

/// <summary>
/// Benchmarks clock reads and UTC guard checks.
/// </summary>
[MemoryDiagnoser]
[ShortRunJob]
public class ClockBenchmarks
{
    private readonly SystemClock _clock = new();
    private readonly DateTime _utcDateTime = new(2026, 1, 1, 12, 30, 0, DateTimeKind.Utc);
    private readonly DateTimeOffset _utcDateTimeOffset = new(2026, 1, 1, 12, 30, 0, TimeSpan.Zero);

    /// <summary>
    /// Reads the current UTC date and time.
    /// </summary>
    /// <returns>The current UTC date and time.</returns>
    [Benchmark]
    public DateTime ReadUtcNow()
    {
        return _clock.UtcNow;
    }

    /// <summary>
    /// Reads the current UTC date and time offset.
    /// </summary>
    /// <returns>The current UTC date and time offset.</returns>
    [Benchmark]
    public DateTimeOffset ReadUtcNowOffset()
    {
        return _clock.UtcNowOffset;
    }

    /// <summary>
    /// Reads the current UTC date.
    /// </summary>
    /// <returns>The current UTC date.</returns>
    [Benchmark]
    public DateOnly ReadTodayUtc()
    {
        return _clock.TodayUtc;
    }

    /// <summary>
    /// Validates a UTC <see cref="DateTime"/> value.
    /// </summary>
    /// <returns>The validated UTC value.</returns>
    [Benchmark]
    public DateTime ValidateUtcDateTime()
    {
        return TimeGuard.AgainstNonUtc(_utcDateTime);
    }

    /// <summary>
    /// Validates a UTC <see cref="DateTimeOffset"/> value.
    /// </summary>
    /// <returns>The validated UTC value.</returns>
    [Benchmark]
    public DateTimeOffset ValidateUtcDateTimeOffset()
    {
        return TimeGuard.AgainstNonUtc(_utcDateTimeOffset);
    }
}
