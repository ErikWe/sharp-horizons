namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

/// <summary>Describes the <see cref="IStepSize"/> in a query as the variable amount of time it takes for the position of the <see cref="ITarget"/> to change by some <see cref="Angle"/>, as seen from the <see cref="IOrigin"/>.</summary>
/// <remarks><see cref="IAngularStepSize"/> is only supported in queries for observational state.</remarks>
public interface IAngularStepSize : IStepSize
{
    /// <summary>The change in position of the <see cref="ITarget"/> per step, as seen from some <see cref="IOrigin"/>.</summary>
    public abstract Angle DeltaAngle { get; }
}
