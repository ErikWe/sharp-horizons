namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Epoch;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IStartEpoch"/>
internal sealed class StartEpoch : IStartEpoch
{
    public required IEpoch Epoch { get; init; }

    /// <summary>Used to compose a <see cref="IStartEpochArgument"/> describing <see langword="this"/>.</summary>
    public required IStartEpochComposer<IEpoch> Composer { private get; init; }

    /// <inheritdoc cref="StartEpoch"/>
    public StartEpoch() { }

    /// <inheritdoc cref="StartEpoch"/>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public StartEpoch(IEpoch epoch, IStartEpochComposer<IEpoch> composer)
    {
        Epoch = epoch;

        Composer = composer;
    }

    IStartEpochArgument IStartEpoch.ComposeArgument() => Composer.Compose(Epoch);
}
