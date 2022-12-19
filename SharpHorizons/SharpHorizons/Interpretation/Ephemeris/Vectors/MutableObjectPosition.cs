namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectPosition"/>
internal sealed record class MutableObjectPosition : IObjectPosition
{
    public IEpoch Epoch { get; set; } = null!;

    /// <summary>The X-component of the 1σ-uncertainty in the <see cref="Position3"/> in the Cartesian directions.</summary>
    public Distance? PositionX { get; set; }

    /// <summary>The Y-component of the <see cref="Position3"/> of the object.</summary>
    public Distance? PositionY { get; set; }

    /// <summary>The Z-component of the <see cref="Position3"/> of the object.</summary>
    public Distance? PositionZ { get; set; }

    Position3 IObjectPosition.Position => new(PositionX!.Value, PositionY!.Value, PositionZ!.Value);

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectPosition"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectPosition"/> is validated.</param>
    public static bool Validate(MutableObjectPosition vectors) => vectors.Epoch is not null && vectors.PositionX is not null && vectors.PositionY is not null && vectors.PositionZ is not null;
}
