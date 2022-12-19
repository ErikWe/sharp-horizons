namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectPositionUncertaintyACN"/>
internal sealed record class MutableObjectPositionUncertaintyACN : IObjectPositionUncertaintyACN
{
    public IEpoch Epoch { get; set; } = null!;

    /// <inheritdoc cref="IObjectPositionUncertaintyACN.AlongTrack"/>
    public Distance? AlongTrack { get; set; }

    /// <inheritdoc cref="IObjectPositionUncertaintyACN.CrossTrack"/>
    public Distance? CrossTrack { get; set; }

    /// <inheritdoc cref="IObjectPositionUncertaintyACN.Normal"/>
    public Distance? Normal { get; set; }

    Distance IObjectPositionUncertaintyACN.AlongTrack => AlongTrack!.Value;
    Distance IObjectPositionUncertaintyACN.CrossTrack => CrossTrack!.Value;
    Distance IObjectPositionUncertaintyACN.Normal => Normal!.Value;

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectPositionUncertaintyACN"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectPositionUncertaintyACN"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyACN vectors) => vectors.Epoch is not null && vectors.AlongTrack is not null && vectors.CrossTrack is not null && vectors.Normal is not null;
}
