namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IAngularStepSize"/>
internal sealed record class AngularStepSize : IAngularStepSize
{
    public required Angle DeltaAngle { get; init; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    public required IStepSizeComposer<IAngularStepSize> Composer { private get; init; }

    /// <inheritdoc cref="AngularStepSize"/>
    public AngularStepSize() { }

    /// <inheritdoc cref="AngularStepSize"/>
    /// <param name="deltaAngle"><inheritdoc cref="DeltaAngle" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public AngularStepSize(Angle deltaAngle, IStepSizeComposer<IAngularStepSize> composer)
    {
        DeltaAngle = deltaAngle;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
