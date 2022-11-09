namespace SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

/// <summary>Describes a <see cref="IOriginCoordinate"/> using a <see cref="CylindricalCoordinate"/>.</summary>
public interface ICylindricalOriginCoordinate : IOriginCoordinate
{
    /// <summary>The <see cref="CylindricalCoordinate"/>, describing the <see cref="IOriginCoordinate"/>.</summary>
    public CylindricalCoordinate Coordinate { get; }
}
