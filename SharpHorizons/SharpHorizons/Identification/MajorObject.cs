namespace SharpHorizons.Identification;

/// <summary>Represents an object marked as a <see cref="HorizonsBodyType.Major"/> body in Horizons - typically a planet, a moon of a planet, a spacecraft, or a few other special cases.</summary>
public sealed record class MajorObject
{
    /// <summary>The ID of the object in Horizons.</summary>
    public MajorObjectID ID { get; }
    /// <summary>The name of the object in Horizons.</summary>
    public MajorObjectName Name { get; }

    /// <summary>Represents an object { <paramref name="id"/>, <paramref name="name"/> } marked as a <see cref="HorizonsBodyType.Major"/> body in Horizons.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public MajorObject(MajorObjectID id, MajorObjectName name)
    {
        ID = id;
        Name = name;
    }
}