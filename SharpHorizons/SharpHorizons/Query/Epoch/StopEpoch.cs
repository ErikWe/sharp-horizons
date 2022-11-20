namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Epoch;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IStopEpoch"/>
internal sealed class StopEpoch : IStopEpoch
{
    public required IEpoch Epoch { get; init; }

    /// <summary>Used to compose a <see cref="IStopEpochArgument"/> describing <see langword="this"/>.</summary>
    public required IStopEpochComposer<IEpoch> Composer { private get; init; }

    /// <inheritdoc cref="StopEpoch"/>
    public StopEpoch() { }

    /// <inheritdoc cref="StopEpoch"/>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public StopEpoch(IEpoch epoch, IStopEpochComposer<IEpoch> composer)
    {
        Epoch = epoch;

        Composer = composer;
    }

    IStopEpochArgument IStopEpoch.ComposeArgument() => Composer.Compose(Epoch);
}
