namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IOrbitalStateVectors"/>.</summary>
internal sealed record class MutableOrbitalStateVectors : IOrbitalStateVectors
{
    public IEpoch Epoch { get; set; } = null!;

    /// <summary>The X-component of the <see cref="Position3"/> of the object.</summary>
    public Distance? PositionX { get; set; }

    /// <summary>The Y-component of the <see cref="Position3"/> of the object.</summary>
    public Distance? PositionY { get; set; }

    /// <summary>The Z-component of the <see cref="Position3"/> of the object.</summary>
    public Distance? PositionZ { get; set; }

    /// <summary>The Z-component of the <see cref="Velocity3"/> of the object.</summary>
    public Speed? VelocityX { get; set; }

    /// <summary>The Z-component of the <see cref="Velocity3"/> of the object.</summary>
    public Speed? VelocityY { get; set; }

    /// <summary>The Z-component of the <see cref="Velocity3"/> of the object.</summary>
    public Speed? VelocityZ { get; set; }

    Position3 IObjectPosition.Position => new(PositionX!.Value, PositionY!.Value, PositionZ!.Value);
    Velocity3 IObjectVelocity.Velocity => new(VelocityX!.Value, VelocityY!.Value, VelocityZ!.Value);

    /// <summary>Determines the validity of the <see cref="MutableOrbitalStateVectors"/> <paramref name="ephemerisEntry"/></summary>
    /// <param name="ephemerisEntry">This <see cref="MutableOrbitalStateVectors"/> is validated.</param>
    public static bool Validate(MutableOrbitalStateVectors ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.PositionX is not null && ephemerisEntry.PositionY is not null && ephemerisEntry.PositionZ is not null && ephemerisEntry.VelocityX is not null && ephemerisEntry.VelocityY is not null && ephemerisEntry.VelocityZ is not null;
}
