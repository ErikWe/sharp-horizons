namespace SharpHorizons.Query.Origin;

/// <summary>Describes the <see cref="IOrigin"/> in a query as a the center of some <see cref="IOriginObject"/>.</summary>
public interface IBodyCentricOrigin : IOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, the center of which represents the <see cref="IOrigin"/> in a query.</summary>
    public abstract IOriginObject OriginObject { get; }
}
