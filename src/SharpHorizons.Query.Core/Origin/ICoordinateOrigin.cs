namespace SharpHorizons.Query.Origin;

/// <summary>Describes the <see cref="IOrigin"/> in a query as some <see cref="IOriginCoordinate"/> relative to some <see cref="IOriginObject"/>.</summary>
public interface ICoordinateOrigin : IOrigin
{
    /// <summary>Some <see cref="IOriginObject"/>, relative to which <see cref="OriginCoordinate"/> is expressed.</summary>
    public abstract IOriginObject OriginObject { get; }

    /// <summary>Some <see cref="IOriginCoordinate"/>, expressed relative to <see cref="OriginObject"/>.</summary>
    public abstract IOriginCoordinate OriginCoordinate { get; }
}
