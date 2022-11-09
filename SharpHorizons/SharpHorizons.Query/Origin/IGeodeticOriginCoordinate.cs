namespace SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

/// <summary>Describes a <see cref="IOriginCoordinate"/> using a <see cref="GeodeticCoordinate"/>.</summary>
public interface IGeodeticOriginCoordinate : IOriginCoordinate
{
    /// <summary>The <see cref="GeodeticCoordinate"/>, describing the <see cref="IOriginCoordinate"/>.</summary>
    public GeodeticCoordinate Coordinate { get; }
}
