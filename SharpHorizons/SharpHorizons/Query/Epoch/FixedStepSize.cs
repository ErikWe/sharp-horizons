namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpMeasures;

/// <inheritdoc cref="IFixedStepSize"/>
internal sealed record class FixedStepSize : IFixedStepSize
{
    /// <inheritdoc/>
    public Time DeltaTime { get; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    private IStepSizeComposer<IFixedStepSize> Composer { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query using a fixed <see cref="Time"/> difference <paramref name="deltaTime"/>.</summary>
    /// <param name="deltaTime"><inheritdoc cref="DeltaTime" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public FixedStepSize(Time deltaTime, IStepSizeComposer<IFixedStepSize> composer)
    {
        DeltaTime = deltaTime;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
