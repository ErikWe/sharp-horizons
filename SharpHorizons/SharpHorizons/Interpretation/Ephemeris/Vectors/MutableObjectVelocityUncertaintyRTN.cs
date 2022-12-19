namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectVelocityUncertaintyRTN"/>
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

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectVelocityUncertaintyRTN"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectVelocityUncertaintyRTN"/> is validated.</param>
    public static bool Validate(MutableObjectVelocityUncertaintyRTN vectors) => vectors.Epoch is not null && vectors.Radial is not null && vectors.Transverse is not null && vectors.Normal is not null;
}
