﻿namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query;

/// <summary>Represents the <see cref="IEpoch"/> marking the start-point of an <see cref="IEpochRange"/>.</summary>
internal interface IStartEpoch
{
    /// <summary>The <see cref="IEpoch"/> representing the start-point of the <see cref="IEpochRange"/>.</summary>
    public abstract IEpoch Epoch { get; }

    /// <summary>Composes a <see cref="IStartEpochArgument"/> describing the <see cref="IStartEpoch"/>.</summary>
    public abstract IStartEpochArgument ComposeArgument();
}
