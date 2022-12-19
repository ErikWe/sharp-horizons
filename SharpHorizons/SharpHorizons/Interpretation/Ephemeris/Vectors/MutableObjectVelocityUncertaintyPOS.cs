namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectVelocityUncertaintyPOS"/>
internal sealed record class MutableObjectVelocityUncertaintyPOS : IObjectVelocityUncertaintyPOS
{
    public IEpoch Epoch { get; set; } = null!;

    /// <inheritdoc cref="IObjectVelocityUncertaintyPOS.Radial"/>
    public Speed? Radial { get; set; }

    /// <inheritdoc cref="IObjectVelocityUncertaintyPOS.RightAscension"/>
    public Speed? RightAscension { get; set; }

    /// <inheritdoc cref="IObjectVelocityUncertaintyPOS.Declination"/>
    public Speed? Declination { get; set; }

    Speed IObjectVelocityUncertaintyPOS.Radial => Radial!.Value;
    Speed IObjectVelocityUncertaintyPOS.RightAscension => RightAscension!.Value;
    Speed IObjectVelocityUncertaintyPOS.Declination => Declination!.Value;

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectVelocityUncertaintyPOS"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectVelocityUncertaintyPOS"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyPOS vectors) => vectors.Epoch is not null && vectors.Radial is not null && vectors.RightAscension is not null && vectors.Declination is not null;
}
