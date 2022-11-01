namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;

using SharpMeasures.Astronomy;

using System;

/// <summary>Allows different types of object identifiers to represent the <see cref="ITarget"/> in a query.</summary>
public static class TargetBuilder
{
    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public static ITarget Represent(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return Represent(majorObject.ID);
    }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID"><inheritdoc cref="MajorObjectIDTarget.ID" path="/summary"/></param>
    public static ITarget Represent(MajorObjectID majorObjectID) => new MajorObjectIDTarget(majorObjectID);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName"><inheritdoc cref="MajorObjectNameTarget.Name" path="/summary"/></param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the object, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public static ITarget Represent(MajorObjectName majorObjectName) => new MajorObjectNameTarget(majorObjectName);

    /// <summary>Describes the <see cref="ITarget"/> in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public static ITarget Represent(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return Represent(majorObject.ID, coordinate);
    }

    /// <summary>Describes the <see cref="ITarget"/> in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public static ITarget Represent(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return Represent(majorObject.ID, coordinate);
    }

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to an object identified by <paramref name="majorObjectID"/>, which represents the <see cref="ITarget"/> in a query.</param>
    public static ITarget Represent(MajorObjectID majorObjectID, CylindricalCoordinate coordinate) => new SiteTarget(new MajorObjectIDTarget(majorObjectID), new CylindricalTargetCoordinate(coordinate));

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to an object identified by <paramref name="majorObjectID"/>, which represents the <see cref="ITarget"/> in a query.</param>
    public static ITarget Represent(MajorObjectID majorObjectID, GeodeticCoordinate coordinate) => new SiteTarget(new MajorObjectIDTarget(majorObjectID), new GeodeticTargetCoordinate(coordinate));

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to an object identified by <paramref name="majorObjectName"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the object, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public static ITarget Represent(MajorObjectName majorObjectName, CylindricalCoordinate coordinate) => new SiteTarget(new MajorObjectNameTarget(majorObjectName), new CylindricalTargetCoordinate(coordinate));

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to an object identified by <paramref name="majorObjectName"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the object, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public static ITarget Represent(MajorObjectName majorObjectName, GeodeticCoordinate coordinate) => new SiteTarget(new MajorObjectNameTarget(majorObjectName), new GeodeticTargetCoordinate(coordinate));

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject">The center of this <see cref="MPCObject"/> represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public static ITarget Represent(MPCObject mpcObject)
    {
        ArgumentNullException.ThrowIfNull(mpcObject);

        return Represent(mpcObject.SequentialNumber);
    }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject">The center of this <see cref="MPCProvisionalObject"/> represents the <see cref="ITarget"/> in a query.</param>
    public static ITarget Represent(MPCProvisionalObject mpcObject) => Represent(mpcObject.Designation);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="mpcName"/>.</summary>
    /// <param name="mpcName"><inheritdoc cref="MPCNameTarget.Name" path="/summary"/></param>
    public static ITarget Represent(MPCName mpcName) => new MPCNameTarget(mpcName);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="mpcDesignation"/>.</summary>
    /// <param name="mpcDesignation"><inheritdoc cref="MPCProvisionalDesignationTarget.Designation" path="/summary"/></param>
    public static ITarget Represent(MPCProvisionalDesignation mpcDesignation) => new MPCProvisionalDesignationTarget(mpcDesignation);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="mpcNumber"/>.</summary>
    /// <param name="mpcNumber"><inheritdoc cref="MPCSequentialNumberTarget.Number" path="/summary"/></param>
    public static ITarget Represent(MPCSequentialNumber mpcNumber) => new MPCSequentialNumberTarget(mpcNumber);
}