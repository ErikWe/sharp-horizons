namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Epoch;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IStartEpoch"/>
internal sealed class StartEpoch : IStartEpoch
{
    public IEpoch Epoch { get; }

    /// <summary>Used to compose a <see cref="IStartEpochArgument"/> describing <see langword="this"/>.</summary>
    private IStartEpochComposer<IEpoch> Composer { get; }

    /// <summary>Uses <paramref name="epoch"/> to represent the start-point of a <see cref="IEpochRange"/>.</summary>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public StartEpoch(IEpoch epoch, IStartEpochComposer<IEpoch> composer)
    {
        Epoch = epoch;

        Composer = composer;
    }

    IStartEpochArgument IStartEpoch.ComposeArgument() => Composer.Compose(Epoch);
}
