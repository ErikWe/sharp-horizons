namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using System;

/// <inheritdoc cref="IUniformStepSizeFactory"/>
internal sealed class UniformStepSizeFactory : IUniformStepSizeFactory
{
    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IUniformStepSize"/>.</summary>
    private IStepSizeComposer<IUniformStepSize> Composer { get; }

    /// <inheritdoc cref="UniformStepSizeFactory"/>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public UniformStepSizeFactory(IStepSizeComposer<IUniformStepSize>? composer = null)
    {
        Composer = composer ?? new UniformStepSizeComposer();
    }

    IUniformStepSize IUniformStepSizeFactory.Create(int stepCount)
    {
        if (stepCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stepCount), stepCount, $"A value greater than 0 should be used to represent the step count of a {nameof(IUniformStepSize)}.");
        }

        return new UniformStepSize(stepCount, Composer);
    }
}
