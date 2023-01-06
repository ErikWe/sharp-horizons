namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectVelocity"/>.</summary>
internal sealed record class MutableObjectVelocity : IObjectVelocity
{
    public IEpoch Epoch { get; set; } = null!;

    /// <summary>The X-component of the <see cref="Velocity3"/> of the object.</summary>
    public Speed? VelocityX { get; set; }

    /// <summary>The Y-component of the <see cref="Velocity3"/> of the object.</summary>
    public Speed? VelocityY { get; set; }

    /// <summary>The Z-component of the <see cref="Velocity3"/> of the object.</summary>
    public Speed? VelocityZ { get; set; }

    Velocity3 IObjectVelocity.Velocity => new(VelocityX!.Value, VelocityY!.Value, VelocityZ!.Value);

    /// <summary>Determines the validity of the <see cref="MutableObjectVelocity"/> <paramref name="ephemerisEntry"/>.</summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectVelocity"/> is validated.</param>
    public static bool Validate(MutableObjectVelocity ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.VelocityX is not null && ephemerisEntry.VelocityY is not null && ephemerisEntry.VelocityZ is not null;
}
