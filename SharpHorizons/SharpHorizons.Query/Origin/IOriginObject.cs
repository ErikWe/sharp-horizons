namespace SharpHorizons.Query.Origin;

/// <summary>Represents an object, relative to which an <see cref="IOrigin"/> is expressed.</summary>
public interface IOriginObject
{
    /// <summary>Composes a <see cref="OriginObjectIdentifier"/> describing the <see cref="IOriginObject"/>.</summary>
    public abstract OriginObjectIdentifier ComposeIdentifier();
}
