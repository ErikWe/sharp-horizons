namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectPosition"/>.</summary>
internal sealed record class MutableObjectPosition : IObjectPosition
{
    public IEpoch Epoch { get; set; } = null!;

    /// <summary>The X-component of the 1σ-uncertainty in the <see cref="Position3"/> in the Cartesian directions.</summary>
    public Distance? PositionX { get; set; }

    /// <summary>The Y-component of the <see cref="Position3"/> of the object.</summary>
    public Distance? PositionY { get; set; }

    /// <summary>The Z-component of the <see cref="Position3"/> of the object.</summary>
    public Distance? PositionZ { get; set; }

    Position3 IObjectPosition.Position => new(PositionX!.Value, PositionY!.Value, PositionZ!.Value);

    /// <summary>Determines the validity of the <see cref="MutableObjectPosition"/> <paramref name="ephemerisEntry"/>.</summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectPosition"/> is validated.</param>
    public static bool Validate(MutableObjectPosition ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.PositionX is not null && ephemerisEntry.PositionY is not null && ephemerisEntry.PositionZ is not null;
}
