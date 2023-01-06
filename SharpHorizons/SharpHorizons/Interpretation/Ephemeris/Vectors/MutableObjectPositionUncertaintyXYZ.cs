namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectPositionUncertaintyXYZ"/>.</summary>
internal sealed record class MutableObjectPositionUncertaintyXYZ : IObjectPositionUncertaintyXYZ
{
    public IEpoch Epoch { get; set; } = null!;

    /// <summary>The X-component of the 1σ-uncertainty in the <see cref="Position3"/> of the object in the Cartesian directions.</summary>
    public Distance? UncertaintyX { get; set; }

    /// <summary>The Y-component of the 1σ-uncertainty in the <see cref="Position3"/> of the object in the Cartesian directions.</summary>
    public Distance? UncertaintyY { get; set; }

    /// <summary>The Z-component of the 1σ-uncertainty in the <see cref="Position3"/> of the object in the Cartesian directions.</summary>
    public Distance? UncertaintyZ { get; set; }

    Displacement3 IObjectPositionUncertaintyXYZ.UncertaintyXYZ => new(UncertaintyX!.Value, UncertaintyY!.Value, UncertaintyZ!.Value);

    /// <summary>Determines the validity of the <see cref="MutableObjectPositionUncertaintyXYZ"/> <paramref name="ephemerisEntry"/>.</summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectPositionUncertaintyXYZ"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyXYZ ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.UncertaintyX is not null && ephemerisEntry.UncertaintyY is not null && ephemerisEntry.UncertaintyZ is not null;
}
