namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectVelocityUncertaintyXYZ"/>.</summary>
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

    /// <summary>Determines the validity of the <see cref="MutableObjectVelocityUncertaintyXYZ"/> <paramref name="ephemerisEntry"/></summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectVelocityUncertaintyXYZ"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyXYZ ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.UncertaintyX is not null && ephemerisEntry.UncertaintyY is not null && ephemerisEntry.UncertaintyZ is not null;
}
