namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;

/// <summary>Represents the <see cref="IEpoch"/> marking the stop-point of an <see cref="IEpochRange"/>.</summary>
internal interface IStopEpoch
{
    /// <summary>The <see cref="IEpoch"/> representing the stop-point of the <see cref="IEpochRange"/>.</summary>
    public abstract IEpoch Epoch { get; }

    /// <summary>Composes a <see cref="IStopEpochArgument"/> describing the <see cref="IStopEpoch"/>.</summary>
    public abstract IStopEpochArgument ComposeArgument();
}
