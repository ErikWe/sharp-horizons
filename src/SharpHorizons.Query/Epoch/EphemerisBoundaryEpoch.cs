namespace SharpHorizons.Query.Epoch;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the <see cref="IStartEpoch"/> or <see cref="IStopEpoch"/> of an <see cref="IEpochRange"/>.</summary>
internal sealed class EphemerisBoundaryEpoch : IStartEpoch, IStopEpoch
{
    /// <summary>The <see cref="IEpoch"/> representing the start- or stop-point of the <see cref="IEpochRange"/>.</summary>
    public required IEpoch Epoch { get; init; }

    /// <inheritdoc cref="EphemerisBoundaryEpoch"/>
    public EphemerisBoundaryEpoch() { }

    /// <inheritdoc cref="EphemerisBoundaryEpoch"/>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    [SetsRequiredMembers]
    public EphemerisBoundaryEpoch(IEpoch epoch)
    {
        Epoch = epoch;
    }
}
