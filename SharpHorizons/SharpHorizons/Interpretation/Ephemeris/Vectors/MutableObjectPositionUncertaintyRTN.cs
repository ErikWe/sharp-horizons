namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectPositionUncertaintyRTN"/>
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

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectPositionUncertaintyRTN"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectPositionUncertaintyRTN"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyRTN vectors) => vectors.Epoch is not null && vectors.Radial is not null && vectors.Transverse is not null && vectors.Normal is not null;
}
