namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

using System;

/// <summary>Handles construction of <see cref="IAngularStepSize"/>, describing the <see cref="IStepSize"/> in a query as the variable amount of time it takes for the position of some <see cref="ITarget"/> to change by some <see cref="Angle"/>, as seen from some <see cref="IOrigin"/>.</summary>
/// <remarks><inheritdoc cref="IAngularStepSize" path="/remarks"/></remarks>
public interface IAngularStepSizeFactory
{
    /// <summary>Describes the <see cref="IStepSize"/> in a query as the variable amount of time it takes for the position of some <see cref="ITarget"/> to change by <paramref name="deltaAngle"/>, as seen from some <see cref="IOrigin"/>.</summary>
    /// <param name="deltaAngle"><inheritdoc cref="IAngularStepSize.DeltaAngle" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IAngularStepSize Create(Angle deltaAngle);
}
