namespace SharpHorizons.Interpretation.Ephemeris;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a reference ellipsoid, relative to which coordinates are expressed - as interpreted from the result of a query.</summary>
public sealed record class ReferenceEllipsoidInterpretation
{
    /// <summary>The name of the <see cref="ReferenceEllipsoidInterpretation"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public required string Name
    {
        get => nameField;
        init
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

            nameField = value;
        }
    }

    /// <summary>Describes how longitude is defined for the <see cref="ReferenceEllipsoidInterpretation"/>.</summary>
    /// <exception cref="InvalidEnumArgumentException"/>
    public required LongitudeDefinition LongitudeDefinition
    {
        get => longitudeDefinitionField;
        init
        {
            InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(value);

            longitudeDefinitionField = value;
        }
    }

    /// <inheritdoc cref="ReferenceEllipsoidInterpretation"/>
    public ReferenceEllipsoidInterpretation() { }

    /// <inheritdoc cref="ReferenceEllipsoidInterpretation"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="longitudeDefinition"><inheritdoc cref="LongitudeDefinition" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    [SetsRequiredMembers]
    public ReferenceEllipsoidInterpretation(string name, LongitudeDefinition longitudeDefinition)
    {
        Name = name;
        LongitudeDefinition = longitudeDefinition;
    }

    /// <summary>Backing field for <see cref="Name"/>. Should not be used elsewhere.</summary>
    private readonly string nameField = null!;
    /// <summary>Backing field for <see cref="LongitudeDefinition"/>. Should not be used elsewhere.</summary>
    private readonly LongitudeDefinition longitudeDefinitionField;
}
