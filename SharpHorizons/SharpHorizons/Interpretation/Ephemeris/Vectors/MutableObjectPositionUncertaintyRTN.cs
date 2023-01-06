namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectPositionUncertaintyRTN"/>.</summary>
internal sealed record class MutableObjectPositionUncertaintyRTN : IObjectPositionUncertaintyRTN
{
    public IEpoch Epoch { get; set; } = null!;

    /// <inheritdoc cref="IObjectPositionUncertaintyRTN.Radial"/>
    public Distance? Radial { get; set; }

    /// <inheritdoc cref="IObjectPositionUncertaintyRTN.Transverse"/>
    public Distance? Transverse { get; set; }

    /// <inheritdoc cref="IObjectPositionUncertaintyRTN.Normal"/>
    public Distance? Normal { get; set; }

    Distance IObjectPositionUncertaintyRTN.Radial => Radial!.Value;
    Distance IObjectPositionUncertaintyRTN.Transverse => Transverse!.Value;
    Distance IObjectPositionUncertaintyRTN.Normal => Normal!.Value;

    /// <summary>Determines the validity of the <see cref="MutableObjectPositionUncertaintyRTN"/> <paramref name="ephemerisEntry"/>.</summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectPositionUncertaintyRTN"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyRTN ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.Radial is not null && ephemerisEntry.Transverse is not null && ephemerisEntry.Normal is not null;
}
