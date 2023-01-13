namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpMeasures;

using System;

/// <inheritdoc cref="IFixedStepSizeFactory"/>
internal sealed class FixedStepSizeFactory : IFixedStepSizeFactory
{
    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IFixedStepSize"/>.</summary>
    private IStepSizeComposer<IFixedStepSize> Composer { get; }

    /// <inheritdoc cref="FixedStepSizeFactory"/>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public FixedStepSizeFactory(IStepSizeComposer<IFixedStepSize>? composer = null)
    {
        Composer = composer ?? new FixedStepSizeComposer();
    }

    IFixedStepSize IFixedStepSizeFactory.Create(Time deltaTime)
    {
        SharpMeasuresValidation.Validate(deltaTime);

        if (deltaTime.IsNegative || deltaTime.IsZero)
        {
            throw new ArgumentOutOfRangeException(nameof(deltaTime), deltaTime, $"A value greater than 0 should be used to represent the delta time of a {nameof(IFixedStepSize)}.");
        }

        return new FixedStepSize(deltaTime, Composer);
    }
}
