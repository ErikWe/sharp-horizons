namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

using System.Globalization;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by a <see cref="MajorObjectID"/>.</summary>
internal sealed record class MajorObjectIDOrigin : IOriginObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="IOriginObject"/> in a query.</summary>
    private MajorObjectID ID { get; }

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by <paramref name="id"/>.</summary>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    public MajorObjectIDOrigin(MajorObjectID id)
    {
        ID = id;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => ID.Value.ToString(CultureInfo.InvariantCulture);
}
