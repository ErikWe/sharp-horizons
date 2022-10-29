namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by a <see cref="MajorObjectName"/>.</summary>
internal sealed record class MajorObjectNameOrigin : IOriginObject
{
    /// <summary>The <see cref="MajorObjectName"/> of an object which represents the <see cref="IOriginObject"/> in a query.</summary>
    private MajorObjectName Name { get; }

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public MajorObjectNameOrigin(MajorObjectName name)
    {
        Name = name;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => Name.Value;
}
