namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents the name of an object classified as a <see cref="HorizonsObjectClass.Major"/> object in Horizons - typically a planet, a moon, or a spacecraft.</summary>
public readonly record struct MajorObjectName
{
    /// <summary>The name of the object in Horizons.</summary>
    public required string Name { get; init; }

    /// <inheritdoc cref="MajorObjectName"/>
    public MajorObjectName() { }

    /// <inheritdoc cref="MajorObjectName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectName(string name)
    {
        Name = name;
    }

    /// <summary>Retrieves the name represented by <see langword="this"/>.</summary>
    public override string ToString() => Name;

    /// <summary>Retrieves the name represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Name.ToString(provider);

    /// <inheritdoc cref="MajorObjectName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public static implicit operator MajorObjectName(string name) => new(name);

    /// <summary>Retrieves the name represented by <paramref name="majorBodyName"/>.</summary>
    /// <param name="majorBodyName"><inheritdoc cref="MajorObjectName" path="/summary"/></param>
    public static implicit operator string(MajorObjectName majorBodyName) => majorBodyName;
}