namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="IOrigin"/>.</summary>
public interface IOriginFactory
{
    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, the center of which represents the <see cref="IOrigin"/> in a query.</param>
    public abstract IOrigin Create(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, the center of which represents the <see cref="IOrigin"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the object, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public abstract IOrigin Create(MajorObjectName majorObjectName);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, CylindricalCoordinate coordinate);

    /// <summary>Describes the v in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to an object identified by <paramref name="majorObjectID"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    public abstract IOrigin Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to an object identified by <paramref name="majorObjectID"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    public abstract IOrigin Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to an object identified by <paramref name="majorObjectName"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the object, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public abstract IOrigin Create(MajorObjectName majorObjectName, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to an object identified by <paramref name="majorObjectName"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the object, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public abstract IOrigin Create(MajorObjectName majorObjectName, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a <paramref name="observationSiteID"/> associated with <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with <paramref name="majorObject"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a <paramref name="observationSiteID"/> associated with an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object which is associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with an object identified by <paramref name="majorObjectID"/>.</param>
    public abstract IOrigin Create(MajorObjectID majorObjectID, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a <paramref name="observationSiteID"/> associated with an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object which is associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with an object identified by <paramref name="majorObjectName"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the object, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public abstract IOrigin Create(MajorObjectName majorObjectName, ObservationSiteID observationSiteID);
}