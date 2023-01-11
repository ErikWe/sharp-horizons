namespace SharpHorizons.Query.Epoch;

/// <summary>Represents the <see cref="IEpoch"/> marking the stop-point of an <see cref="IEpochRange"/>.</summary>
public interface IStopEpoch
{
    /// <summary>The <see cref="IEpoch"/> representing the stop-point of the <see cref="IEpochRange"/>.</summary>
    public abstract IEpoch Epoch { get; }
}
