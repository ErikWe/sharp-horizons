namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectPositionUncertaintyPOS"/>
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

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectPositionUncertaintyPOS"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectPositionUncertaintyPOS"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyPOS vectors) => vectors.Epoch is not null && vectors.Radial is not null && vectors.RightAscension is not null && vectors.Declination is not null;
}
