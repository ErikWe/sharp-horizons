namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpMeasures;

using System;

/// <inheritdoc cref="IAngularStepSizeFactory"/>
internal sealed class AngularStepSizeFactory : IAngularStepSizeFactory
{
    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IAngularStepSize"/>.</summary>
    private IStepSizeComposer<IAngularStepSize> Composer { get; }

    /// <inheritdoc cref="AngularStepSizeFactory"/>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public AngularStepSizeFactory(IStepSizeComposer<IAngularStepSize>? composer = null)
    {
        Composer = composer ?? new AngularStepSizeComposer();
    }

    IAngularStepSize IAngularStepSizeFactory.Create(Angle deltaAngle)
    {
        SharpMeasuresValidation.Validate(deltaAngle);

        if (deltaAngle.IsNegative || deltaAngle.IsZero)
        {
            throw new ArgumentOutOfRangeException(nameof(deltaAngle), deltaAngle, $"A value greater than 0 should be used to represent the delta angle of a {nameof(IAngularStepSize)}.");
        }

        return new AngularStepSize(deltaAngle, Composer);
    }
}
