namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IFixedStepSize"/>
internal sealed record class FixedStepSize : IFixedStepSize
{
    public required Time DeltaTime { get; init; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    public required IStepSizeComposer<IFixedStepSize> Composer { private get; init; }

    /// <inheritdoc cref="FixedStepSize"/>
    public FixedStepSize() { }

    /// <inheritdoc cref="FixedStepSize"/>
    /// <param name="deltaTime"><inheritdoc cref="DeltaTime" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public FixedStepSize(Time deltaTime, IStepSizeComposer<IFixedStepSize> composer)
    {
        DeltaTime = deltaTime;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
