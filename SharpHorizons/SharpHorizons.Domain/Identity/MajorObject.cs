namespace SharpHorizons.Identity;

/// <summary>Represents an object classified as a <see cref="HorizonsObjectClass.Major"/> object in Horizons - typically a planet, a moon, or a spacecraft.</summary>
public sealed record class MajorObject
{
    /// <summary>The ID of the object in Horizons.</summary>
    public MajorObjectID ID { get; }
    /// <summary>The name of the object in Horizons.</summary>
    public MajorObjectName Name { get; }

    /// <summary>Represents an object { <paramref name="id"/>, <paramref name="name"/> } classified as a <see cref="HorizonsObjectClass.Major"/> object in Horizons - typically a planet, a moon, or a spacecraft.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public MajorObject(MajorObjectID id, MajorObjectName name)
    {
        ID = id;
        Name = name;
    }
}