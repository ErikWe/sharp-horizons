namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IUniformStepSize"/>
internal sealed record class UniformStepSize : IUniformStepSize
{
    public int StepCount { get; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    private IStepSizeComposer<IUniformStepSize> Composer { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query using <paramref name="stepCount"/> uniformly distributed steps.</summary>
    /// <param name="stepCount"><inheritdoc cref="StepCount" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public UniformStepSize(int stepCount, IStepSizeComposer<IUniformStepSize> composer)
    {
        StepCount = stepCount;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
