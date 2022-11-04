namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

/// <inheritdoc cref="IAngularStepSize"/>
internal sealed record class AngularStepSize : IAngularStepSize
{
    /// <inheritdoc/>
    public Angle DeltaAngle { get; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    private IStepSizeComposer<IAngularStepSize> Composer { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query as the variable amount of time it takes for the position of the <see cref="ITarget"/> to change by <paramref name="deltaAngle"/>, as seen from the <see cref="IOrigin"/>.</summary>
    /// <param name="deltaAngle"><inheritdoc cref="DeltaAngle" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <remarks><inheritdoc cref="IAngularStepSize" path="/remarks"/></remarks>
    public AngularStepSize(Angle deltaAngle, IStepSizeComposer<IAngularStepSize> composer)
    {
        DeltaAngle = deltaAngle;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
