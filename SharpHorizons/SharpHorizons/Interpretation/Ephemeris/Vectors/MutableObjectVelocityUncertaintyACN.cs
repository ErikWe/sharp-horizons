namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectVelocityUncertaintyACN"/>
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

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectVelocityUncertaintyACN"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectVelocityUncertaintyACN"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyACN vectors) => vectors.Epoch is not null && vectors.AlongTrack is not null && vectors.CrossTrack is not null && vectors.Normal is not null;
}
