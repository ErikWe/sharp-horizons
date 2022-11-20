namespace SharpHorizons.Identity;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an object classified as a <see cref="HorizonsObjectClass.Major"/> object in Horizons - typically a planet, a moon, or a spacecraft.</summary>
public sealed record class MajorObject
{
    /// <summary>The ID of the object in Horizons.</summary>
    public required MajorObjectID ID { get; init; }

    /// <summary>The name of the object in Horizons, or <see langword="null"/> if the object is unnamed.</summary>
    public MajorObjectName? Name { get; init; }

    /// <inheritdoc cref="MajorObject"/>
    public MajorObject() { }

    /// <inheritdoc cref="MajorObject"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObject(MajorObjectID id)
    {
        ID = id;
    }

    /// <inheritdoc cref="MajorObject"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObject(MajorObjectID id, MajorObjectName? name)
    {
        ID = id;
        Name = name;
    }
}