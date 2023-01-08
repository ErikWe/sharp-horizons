namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectVelocityUncertaintyPOS"/>.</summary>
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

    /// <summary>Determines the validity of the <see cref="MutableObjectVelocityUncertaintyPOS"/> <paramref name="ephemerisEntry"/></summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectVelocityUncertaintyPOS"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyPOS ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.Radial is not null && ephemerisEntry.RightAscension is not null && ephemerisEntry.Declination is not null;
}
