namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="ITargetSite"/>.</summary>
public interface ITargetSiteFactory
{
    /// <summary>Describes the <see cref="ITargetSite"/> in a query as <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate">The <see cref="CylindricalCoordinate"/> which represents the <see cref="ITargetSite"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    public abstract ITargetSite Create(CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITargetSite"/> in a query as <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate">The <see cref="GeodeticCoordinate"/> which represents the <see cref="ITargetSite"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    public abstract ITargetSite Create(GeodeticCoordinate coordinate);
}
