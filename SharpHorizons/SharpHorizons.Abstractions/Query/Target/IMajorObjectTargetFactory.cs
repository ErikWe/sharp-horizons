﻿namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="ITarget"/> associated with <see cref="MajorObject"/>.</summary>
public interface IMajorObjectTargetFactory
{
    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(MajorObject majorObject);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</param>
    public abstract ITarget Create(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="ObjectRadiiInterpretation"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="ObjectRadiiInterpretation"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract ITarget Create(ObjectRadiiInterpretation majorObjectName);

    /// <summary>Describes the <see cref="ITarget"/> in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(MajorObject majorObject, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in a query as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(MajorObject majorObject, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    public abstract ITarget Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentException"/>
    public abstract ITarget Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="ObjectRadiiInterpretation"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="ObjectRadiiInterpretation"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract ITarget Create(ObjectRadiiInterpretation majorObjectName, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="ObjectRadiiInterpretation"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="ITarget"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="ObjectRadiiInterpretation"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract ITarget Create(ObjectRadiiInterpretation majorObjectName, GeodeticCoordinate coordinate);
}
