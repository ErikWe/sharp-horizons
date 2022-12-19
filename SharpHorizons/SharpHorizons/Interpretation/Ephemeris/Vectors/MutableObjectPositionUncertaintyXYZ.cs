namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectPositionUncertaintyXYZ"/>
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

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectPositionUncertaintyXYZ"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectPositionUncertaintyXYZ"/> is validated.</param>
    public static bool Validate(MutableObjectPositionUncertaintyXYZ vectors) => vectors.Epoch is not null && vectors.UncertaintyX is not null && vectors.UncertaintyY is not null && vectors.UncertaintyZ is not null;
}
