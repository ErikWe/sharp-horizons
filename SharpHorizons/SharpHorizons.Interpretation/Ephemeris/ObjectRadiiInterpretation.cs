namespace SharpHorizons.Interpretation.Ephemeris;

using SharpMeasures;

/// <summary>Describes the radii of an object along different axes - as interpreted from the result of a query.</summary>
public sealed record class ObjectRadiiInterpretation
{
    /// <summary>The mean equatorial radius of the object, if provided.</summary>
    public Distance? Equator { get; init; }

    /// <summary>The mean radius along the prime meridian of the object, if provided.</summary>
    public Distance? Meridian { get; init; }

    /// <summary>The polar radius of the object, if provided.</summary>
    public Distance? Pole { get; init; }

    /// <inheritdoc cref="ObjectRadiiInterpretation"/>
    public ObjectRadiiInterpretation() { }
}
