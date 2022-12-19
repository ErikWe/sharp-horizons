namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectVelocityUncertaintyXYZ"/>
internal sealed record class MutableObjectVelocityUncertaintyXYZ : IObjectVelocityUncertaintyXYZ
{
    public IEpoch Epoch { get; set; } = null!;

    /// <summary>The X-component of the 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the Cartesian directions.</summary>
    public Speed? UncertaintyX { get; set; }

    /// <summary>The Y-component of the 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the Cartesian directions.</summary>
    public Speed? UncertaintyY { get; set; }

    /// <summary>The Z-component of the 1σ-uncertainty in the <see cref="Velocity3"/> of the object in the Cartesian directions.</summary>
    public Speed? UncertaintyZ { get; set; }

    Velocity3 IObjectVelocityUncertaintyXYZ.UncertaintyXYZ => new(UncertaintyX!.Value, UncertaintyY!.Value, UncertaintyZ!.Value);

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectVelocityUncertaintyXYZ"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectVelocityUncertaintyXYZ"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyXYZ vectors) => vectors.Epoch is not null && vectors.UncertaintyX is not null && vectors.UncertaintyY is not null && vectors.UncertaintyZ is not null;
}
