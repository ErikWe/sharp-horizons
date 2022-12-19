namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectVelocity"/>
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

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectVelocity"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectVelocity"/> is validated.</param>
    public static bool Validate(MutableObjectVelocity vectors) => vectors.Epoch is not null && vectors.VelocityX is not null && vectors.VelocityY is not null && vectors.VelocityZ is not null;
}
