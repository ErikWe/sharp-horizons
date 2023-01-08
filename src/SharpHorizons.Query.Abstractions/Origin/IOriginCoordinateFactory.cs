namespace SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="IOriginCoordinate"/>.</summary>
public interface IOriginCoordinateFactory
{
    /// <summary>Describes <paramref name="coordinate"/> as an <see cref="IOriginCoordinate"/>.</summary>
    /// <param name="coordinate">This <see cref="CylindricalCoordinate"/> is described as a <see cref="IOriginCoordinate"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginCoordinate Create(CylindricalCoordinate coordinate);

    /// <summary>Describes <paramref name="coordinate"/> as an <see cref="IOriginCoordinate"/>.</summary>
    /// <param name="coordinate">This <see cref="GeodeticCoordinate"/> is described as a <see cref="IOriginCoordinate"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginCoordinate Create(GeodeticCoordinate coordinate);
}
