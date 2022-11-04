namespace SharpHorizons.Query.Origin;

/// <summary>Describes the <see cref="IOrigin"/> in a query as a <see cref="IOriginCoordinate"/> relative to an <see cref="IOriginObject"/>.</summary>
public interface ICoordinateOrigin : IOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, relative to which <see cref="OriginCoordinate"/> is expressed.</summary>
    public abstract IOriginObject OriginObject { get; }

    /// <summary>The <see cref="IOriginCoordinate"/> relative to <see cref="OriginObject"/>.</summary>
    public abstract IOriginCoordinate OriginCoordinate { get; }
}
