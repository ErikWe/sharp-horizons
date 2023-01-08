namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectVelocityUncertaintyRTN"/>.</summary>
internal sealed record class MutableObjectVelocityUncertaintyRTN : IObjectVelocityUncertaintyRTN
{
    public IEpoch Epoch { get; set; } = null!;

    /// <inheritdoc cref="IObjectVelocityUncertaintyRTN.Radial"/>
    public Speed? Radial { get; set; }

    /// <inheritdoc cref="IObjectVelocityUncertaintyRTN.Transverse"/>
    public Speed? Transverse { get; set; }

    /// <inheritdoc cref="IObjectVelocityUncertaintyRTN.Normal"/>
    public Speed? Normal { get; set; }

    Speed IObjectVelocityUncertaintyRTN.Radial => Radial!.Value;
    Speed IObjectVelocityUncertaintyRTN.Transverse => Transverse!.Value;
    Speed IObjectVelocityUncertaintyRTN.Normal => Normal!.Value;

    /// <summary>Determines the validity of the <see cref="MutableObjectVelocityUncertaintyRTN"/> <paramref name="ephemerisEntry"/></summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectVelocityUncertaintyRTN"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyRTN ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.Radial is not null && ephemerisEntry.Transverse is not null && ephemerisEntry.Normal is not null;
}
