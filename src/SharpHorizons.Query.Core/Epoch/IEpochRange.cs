namespace SharpHorizons.Query.Epoch;

/// <summary>Uses the timespan between two <see cref="IEpoch"/> and an associated <see cref="IStepSize"/> to describe the <see cref="IEpochSelection"/> in a query.</summary>
public interface IEpochRange : IEpochSelection
{
    /// <summary>The start-point of the <see cref="IEpochRange"/>.</summary>
    public abstract IStartEpoch StartEpoch { get; }

    /// <summary>The stop-point of the <see cref="IEpochRange"/>.</summary>
    public abstract IStopEpoch StopEpoch { get; }

    /// <summary>The <see cref="IStepSize"/>, describing the difference between each <see cref="IEpoch"/> in the <see cref="IEpochSelection"/>.</summary>
    public abstract IStepSize StepSize { get; }
}
