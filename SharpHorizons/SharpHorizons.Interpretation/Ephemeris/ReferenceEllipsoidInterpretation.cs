namespace SharpHorizons.Interpretation.Ephemeris;

/// <summary>Represents a reference ellipsoid, relative to which coordinates are expressed - as interpreted from the result of a query.</summary>
public readonly record struct ReferenceEllipsoidInterpretation
{
    /// <summary>The name of the <see cref="ReferenceEllipsoidInterpretation"/>.</summary>
    public required string Name { get; init; }

    /// <summary>Describes how longitude is defined for the <see cref="ReferenceEllipsoidInterpretation"/>.</summary>
    public required LongitudeInterpretation LongitudeDefinition { get; init; }

    /// <inheritdoc cref="ReferenceEllipsoidInterpretation"/>
    public ReferenceEllipsoidInterpretation() { }

    /// <inheritdoc cref="ReferenceEllipsoidInterpretation"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="longitudeDefinition"><inheritdoc cref="LongitudeDefinition" path="/summary"/></param>
    public ReferenceEllipsoidInterpretation(string name, LongitudeInterpretation longitudeDefinition)
    {
        Name = name;
        LongitudeDefinition = longitudeDefinition;
    }
}
