namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Composers;

/// <inheritdoc cref="IStopEpoch"/>
internal sealed class StopEpoch : IStopEpoch
{
    /// <inheritdoc/>
    public IEpoch Epoch { get; }

    /// <summary>Used to compose a <see cref="IStopEpochArgument"/> describing <see langword="this"/>.</summary>
    private IStopEpochComposer<IEpoch> Composer { get; }

    /// <summary>Uses <paramref name="epoch"/> to represent the stop-point of a <see cref="IEpochRange"/>.</summary>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public StopEpoch(IEpoch epoch, IStopEpochComposer<IEpoch> composer)
    {
        Epoch = epoch;

        Composer = composer;
    }

    IStopEpochArgument IStopEpoch.ComposeArgument() => Composer.Compose(Epoch);
}
