namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="ITarget"/>.</summary>
public interface ITargetFactory : IMajorObjectTargetFactory, IMPCTargetFactory, IMPCCometTargetFactory
{
    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of some <paramref name="targetObject"/>.</summary>
    /// <param name="targetObject">Some <see cref="ITargetObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(ITargetObject targetObject);

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of some <paramref name="targetObject"/>.</summary>
    /// <param name="targetObject">Some <see cref="ITargetObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="targetObject"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(ITargetObject targetObject, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of some <paramref name="targetObject"/>.</summary>
    /// <param name="targetObject">Some <see cref="ITargetObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="targetObject"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(ITargetObject targetObject, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in a query as some <paramref name="site"/> associated with some <paramref name="targetObject"/>.</summary>
    /// <param name="targetObject">Some <see cref="ITargetObject"/>, relative to which <paramref name="site"/> is expressed.</param>
    /// <param name="site">Some <see cref="ITargetSite"/>, associated with <paramref name="targetObject"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(ITargetObject targetObject, ITargetSite site);
}
