namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

/// <summary>Describes the <see cref="IStepSize"/> in a query using a fixed <see cref="Time"/>.</summary>
public interface IFixedStepSize : IStepSize
{
    /// <summary>The <see cref="Time"/> between each step.</summary>
    public abstract Time DeltaTime { get; }
}
