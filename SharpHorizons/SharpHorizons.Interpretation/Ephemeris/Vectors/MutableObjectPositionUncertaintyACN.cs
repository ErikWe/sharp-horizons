namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectPositionUncertaintyACN"/>.</summary>
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

    /// <summary>Determines the validity of the <see cref="MutableObjectPositionUncertaintyACN"/> <paramref name="ephemerisEntry"/>.</summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectPositionUncertaintyACN"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyACN ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.AlongTrack is not null && ephemerisEntry.CrossTrack is not null && ephemerisEntry.Normal is not null;
}
