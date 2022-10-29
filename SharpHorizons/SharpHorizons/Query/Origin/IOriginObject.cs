namespace SharpHorizons.Query.Origin;

/// <summary>Represents the origin object in a query.</summary>
internal interface IOriginObject
{
    /// <summary>Composes a <see cref="OriginObjectIdentifier"/> describing the origin object in a query.</summary>
    internal abstract OriginObjectIdentifier ComposeIdentifier();
}