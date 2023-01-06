namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectPositionUncertaintyPOS"/>.</summary>
internal sealed record class MutableObjectPositionUncertaintyPOS : IObjectPositionUncertaintyPOS
{
    public IEpoch Epoch { get; set; } = null!;

    /// <inheritdoc cref="IObjectPositionUncertaintyPOS.Radial"/>
    public Distance? Radial { get; set; }

    /// <inheritdoc cref="IObjectPositionUncertaintyPOS.RightAscension"/>
    public Distance? RightAscension { get; set; }

    /// <inheritdoc cref="IObjectPositionUncertaintyPOS.Declination"/>
    public Distance? Declination { get; set; }

    Distance IObjectPositionUncertaintyPOS.Radial => Radial!.Value;
    Distance IObjectPositionUncertaintyPOS.RightAscension => RightAscension!.Value;
    Distance IObjectPositionUncertaintyPOS.Declination => Declination!.Value;

    /// <summary>Determines the validity of the <see cref="MutableObjectPositionUncertaintyPOS"/> <paramref name="ephemerisEntry"/>.</summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectPositionUncertaintyPOS"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyPOS ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.Radial is not null && ephemerisEntry.RightAscension is not null && ephemerisEntry.Declination is not null;
}
