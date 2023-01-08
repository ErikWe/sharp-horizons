namespace SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="IOrigin"/>.</summary>
public interface IOriginFactory
{
    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="IOrigin"/> in a query.</param>
    public abstract IOrigin Create(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="IOrigin"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(MajorObjectName majorObjectName);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of some <paramref name="originObject"/>.</summary>
    /// <param name="originObject">Some <see cref="IOriginObject"/>, the center of which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(IOriginObject originObject);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as some <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">Some <see cref="IOriginCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, IOriginCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as some <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">Some <see cref="IOriginCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObjectID majorObjectID, IOriginCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(MajorObjectName majorObjectName, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(MajorObjectName majorObjectName, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as some <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">Some <see cref="IOriginCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObjectName majorObjectName, IOriginCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of some <paramref name="originObject"/>.</summary>
    /// <param name="originObject">Some <see cref="IOriginObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="originObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(IOriginObject originObject, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="coordinate"/> relative to the center of some <paramref name="originObject"/>.</summary>
    /// <param name="originObject">some <see cref="IOriginObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="originObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(IOriginObject originObject, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as some <paramref name="coordinate"/> relative to the center of some <paramref name="originObject"/>.</summary>
    /// <param name="originObject">Some <see cref="IOriginObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">Some <see cref="IOriginCoordinate"/>, relative to <paramref name="originObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(IOriginObject originObject, IOriginCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="ObservationSite"/>, identified by <paramref name="observationSiteID"/>, associated with <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> of an <see cref="ObservationSite"/> associated with <paramref name="majorObject"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="ObservationSite"/>, identified by <paramref name="observationSiteID"/>, associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/> which is associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> of an <see cref="ObservationSite"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(MajorObjectID majorObjectID, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="ObservationSite"/>, identified by <paramref name="observationSiteID"/>, associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/> which is associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> of an <see cref="ObservationSite"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(MajorObjectName majorObjectName, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="ObservationSite"/>, identified by <paramref name="observationSiteID"/>, associated with some <paramref name="originObject"/>.</summary>
    /// <param name="originObject">Some <see cref="IOriginObject"/> which is associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> of an <see cref="ObservationSite"/> associated with some <paramref name="originObject"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOrigin Create(IOriginObject originObject, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <paramref name="observationSite"/> associated with <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, associated with <paramref name="observationSite"/>.</param>
    /// <param name="observationSite">An <see cref="ObservationSite"/> associated with <paramref name="majorObject"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObject majorObject, ObservationSite observationSite);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <paramref name="observationSite"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/> which is associated with <paramref name="observationSite"/>.</param>
    /// <param name="observationSite">An <see cref="ObservationSite"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObjectID majorObjectID, ObservationSite observationSite);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <paramref name="observationSite"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/> which is associated with <paramref name="observationSite"/>.</param>
    /// <param name="observationSite">An <see cref="ObservationSite"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(MajorObjectName majorObjectName, ObservationSite observationSite);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as an <paramref name="observationSite"/> associated with some <paramref name="originObject"/>.</summary>
    /// <param name="originObject">Some <see cref="IOriginObject"/> which is associated with <paramref name="observationSite"/>.</param>
    /// <param name="observationSite">An <see cref="ObservationSite"/> associated with some <paramref name="originObject"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOrigin Create(IOriginObject originObject, ObservationSite observationSite);
}
