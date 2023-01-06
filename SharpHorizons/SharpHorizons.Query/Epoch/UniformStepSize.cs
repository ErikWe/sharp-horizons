namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IUniformStepSize"/>
internal sealed record class UniformStepSize : IUniformStepSize
{
    public required int StepCount { get; init; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    public required IStepSizeComposer<IUniformStepSize> Composer { private get; init; }

    /// <inheritdoc cref="UniformStepSize"/>
    public UniformStepSize() { }

    /// <inheritdoc cref="UniformStepSize"/>
    /// <param name="stepCount"><inheritdoc cref="StepCount" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public UniformStepSize(int stepCount, IStepSizeComposer<IUniformStepSize> composer)
    {
        StepCount = stepCount;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
