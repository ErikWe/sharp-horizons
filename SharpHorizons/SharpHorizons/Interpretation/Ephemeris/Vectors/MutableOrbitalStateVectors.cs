namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IOrbitalStateVectors"/>
internal sealed record class MutableOrbitalStateVectors : IOrbitalStateVectors
{
    public IEpoch Epoch { get; set; } = null!;

    public Distance? PositionX { get; set; }
    public Distance? PositionY { get; set; }
    public Distance? PositionZ { get; set; }

    public Speed? VelocityX { get; set; }
    public Speed? VelocityY { get; set; }
    public Speed? VelocityZ { get; set; }

    Position3 IPositionEphemerisEntry.Position => new(PositionX!.Value, PositionY!.Value, PositionZ!.Value);
    Velocity3 IVelocityEphemerisEntry.Velocity => new(VelocityX!.Value, VelocityY!.Value, VelocityZ!.Value);

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IOrbitalStateVectors"/>.</summary>
    /// <param name="vectors">This <see cref="IOrbitalStateVectors"/> is validated.</param>
    public static bool Validate(MutableOrbitalStateVectors vectors) => vectors.Epoch is not null && vectors.PositionX is not null && vectors.PositionY is not null && vectors.PositionZ is not null && vectors.VelocityX is not null && vectors.VelocityY is not null && vectors.VelocityZ is not null;
}
