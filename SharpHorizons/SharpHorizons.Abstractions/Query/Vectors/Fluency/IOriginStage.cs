namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System;

/// <summary>Provides means of selecting the <see cref="IOrigin"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface IOriginStage
{
    /// <summary>Uses <paramref name="origin"/> as the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="origin">The <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochStage WithOrigin(IOrigin origin);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochStage WithOrigin(MajorObject majorObject);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    public abstract IEpochStage WithOrigin(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochStage WithOrigin(MajorObjectName majorObjectName);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochStage WithOrigin(MajorObject majorObject, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochStage WithOrigin(MajorObject majorObject, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochStage WithOrigin(MajorObjectID majorObjectID, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochStage WithOrigin(MajorObjectID majorObjectID, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochStage WithOrigin(MajorObjectName majorObjectName, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochStage WithOrigin(MajorObjectName majorObjectName, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as a <paramref name="observationSiteID"/> associated with <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with <paramref name="majorObject"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochStage WithOrigin(MajorObject majorObject, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as a <paramref name="observationSiteID"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/> which is associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochStage WithOrigin(MajorObjectID majorObjectID, ObservationSiteID observationSiteID);

    /// <summary>Describes the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> as a <paramref name="observationSiteID"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/> which is associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochStage WithOrigin(MajorObjectName majorObjectName, ObservationSiteID observationSiteID);
}
