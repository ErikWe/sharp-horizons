namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectVelocityUncertaintyACN"/>.</summary>
internal sealed record class MutableObjectVelocityUncertaintyACN : IObjectVelocityUncertaintyACN
{
    public IEpoch Epoch { get; set; } = null!;

    /// <inheritdoc cref="IObjectVelocityUncertaintyACN.AlongTrack"/>
    public Speed? AlongTrack { get; set; }

    /// <inheritdoc cref="IObjectVelocityUncertaintyACN.CrossTrack"/>
    public Speed? CrossTrack { get; set; }

    /// <inheritdoc cref="IObjectVelocityUncertaintyACN.Normal"/>
    public Speed? Normal { get; set; }

    Speed IObjectVelocityUncertaintyACN.AlongTrack => AlongTrack!.Value;
    Speed IObjectVelocityUncertaintyACN.CrossTrack => CrossTrack!.Value;
    Speed IObjectVelocityUncertaintyACN.Normal => Normal!.Value;

    /// <summary>Determines the validity of the <see cref="MutableObjectVelocityUncertaintyACN"/> <paramref name="ephemerisEntry"/></summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectVelocityUncertaintyACN"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyACN ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.AlongTrack is not null && ephemerisEntry.CrossTrack is not null && ephemerisEntry.Normal is not null;
}
