// <copyright file="IClock.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Time;

/// <summary>
/// Represents an abstraction for accessing the current UTC time in a test-friendly way.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets the current UTC date and time.
    /// </summary>
    public DateTime UtcNow
    {
        get;
    }

    /// <summary>
    /// Gets the current UTC date and time with offset information.
    /// </summary>
    public DateTimeOffset UtcNowOffset
    {
        get;
    }

    /// <summary>
    /// Gets the current UTC calendar date.
    /// </summary>
    public DateOnly TodayUtc
    {
        get;
    }
}
