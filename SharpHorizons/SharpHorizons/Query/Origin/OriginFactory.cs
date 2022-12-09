namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Origin;

using SharpMeasures.Astronomy;

using System;

/// <summary>Handles construction of <see cref="IOrigin"/>.</summary>
public sealed class OriginFactory : IOriginFactory
{
    /// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="IBodyCentricOrigin"/>.</summary>
    private IOriginComposer<IBodyCentricOrigin> BodyCentricComposer { get; }

    /// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="ICoordinateOrigin"/>.</summary>
    private IOriginComposer<ICoordinateOrigin> CoordinateComposer { get; }

    /// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="IObservationSiteOrigin"/>.</summary>
    private IOriginComposer<IObservationSiteOrigin> ObservationSiteComposer { get; }

    /// <inheritdoc cref="IOriginObjectFactory"/>
    private IOriginObjectFactory OriginObjectFactory { get; }

    /// <summary>Handles construction of <see cref="IOriginCoordinate"/> describing <see cref="CylindricalCoordinate"/>.</summary>
    private IOriginCoordinateFactory<CylindricalCoordinate> CylindricalCoordinateFactory { get; }

    /// <summary>Handles construction of <see cref="IOriginCoordinate"/> describing <see cref="GeodeticCoordinate"/>.</summary>
    private IOriginCoordinateFactory<GeodeticCoordinate> GeodeticCoordinateFactory { get; }

    /// <inheritdoc cref="OriginFactory"/>
    /// <param name="bodyCentricComposer"><inheritdoc cref="BodyCentricComposer" path="/summary"/></param>
    /// <param name="coordinateComposer"><inheritdoc cref="CoordinateComposer" path="/summary"/></param>
    /// <param name="observationSiteComoser"><inheritdoc cref="ObservationSiteComposer" path="/summary"/></param>
    /// <param name="originObjectFactory"><inheritdoc cref="OriginObjectFactory" path="/summary"/></param>
    /// <param name="cylindricalCoordinateFactory"><inheritdoc cref="CylindricalCoordinateFactory" path="/summary"/></param>
    /// <param name="geodeticCoordinateFactory"><inheritdoc cref="GeodeticCoordinateFactory" path="/summary"/></param>
    public OriginFactory(IOriginComposer<IBodyCentricOrigin>? bodyCentricComposer = null, IOriginComposer<ICoordinateOrigin>? coordinateComposer = null, IOriginComposer<IObservationSiteOrigin>? observationSiteComoser = null, IOriginObjectFactory? originObjectFactory = null, IOriginCoordinateFactory<CylindricalCoordinate>? cylindricalCoordinateFactory = null, IOriginCoordinateFactory<GeodeticCoordinate>? geodeticCoordinateFactory = null)
    {
        BodyCentricComposer = bodyCentricComposer ?? new BodyCentricOriginComposer();
        CoordinateComposer = coordinateComposer ?? new CoordinateOriginComposer();
        ObservationSiteComposer = observationSiteComoser ?? new ObservationSiteOriginComposer();

        OriginObjectFactory = originObjectFactory ?? new OriginObjectFactory();

        CylindricalCoordinateFactory = cylindricalCoordinateFactory ?? new CylindricalOriginCoordinateFactory();
        GeodeticCoordinateFactory = geodeticCoordinateFactory ?? new GeodeticOriginCoordinateFactory();
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return CreateOrigin(CreateOriginObject(majorObject));
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObjectID majorObjectID) => CreateOrigin(CreateOriginObject(majorObjectID));

    /// <inheritdoc/>
    public IOrigin Create(ObjectRadiiInterpretation majorObjectName)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);

        return CreateOrigin(CreateOriginObject(majorObjectName));
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObject majorObject, CylindricalCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateOrigin(CreateOriginObject(majorObject), CreateOriginCoordinate(coordinate));
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObject majorObject, GeodeticCoordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateOrigin(CreateOriginObject(majorObject), CreateOriginCoordinate(coordinate));
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObjectID majorObjectID, CylindricalCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return CreateOrigin(CreateOriginObject(majorObjectID), CreateOriginCoordinate(coordinate));
    }
    /// <inheritdoc/>
    public IOrigin Create(MajorObjectID majorObjectID, GeodeticCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return CreateOrigin(CreateOriginObject(majorObjectID), CreateOriginCoordinate(coordinate));
    }

    /// <inheritdoc/>
    public IOrigin Create(ObjectRadiiInterpretation majorObjectName, CylindricalCoordinate coordinate)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateOrigin(CreateOriginObject(majorObjectName), CreateOriginCoordinate(coordinate));
    }

    /// <inheritdoc/>
    public IOrigin Create(ObjectRadiiInterpretation majorObjectName, GeodeticCoordinate coordinate)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);
        SharpMeasuresValidation.Validate(coordinate);

        return CreateOrigin(CreateOriginObject(majorObjectName), CreateOriginCoordinate(coordinate));
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObject majorObject, ObservationSiteID observationSiteID)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        ObservationSiteID.Validate(observationSiteID);

        return CreateOrigin(CreateOriginObject(majorObject), observationSiteID);
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObjectID majorObjectID, ObservationSiteID observationSiteID)
    {
        ObservationSiteID.Validate(observationSiteID);

        return CreateOrigin(CreateOriginObject(majorObjectID), observationSiteID);
    }

    /// <inheritdoc/>
    public IOrigin Create(ObjectRadiiInterpretation majorObjectName, ObservationSiteID observationSiteID)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);
        ObservationSiteID.Validate(observationSiteID);

        return CreateOrigin(CreateOriginObject(majorObjectName), observationSiteID);
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObject majorObject, ObservationSite observationSite)
    {
        ArgumentNullException.ThrowIfNull(majorObject);
        ArgumentNullException.ThrowIfNull(observationSite);

        return Create(majorObject, observationSite.ID);
    }

    /// <inheritdoc/>
    public IOrigin Create(MajorObjectID majorObjectID, ObservationSite observationSite)
    {
        ArgumentNullException.ThrowIfNull(observationSite);

        return Create(majorObjectID, observationSite.ID);
    }

    /// <inheritdoc/>
    public IOrigin Create(ObjectRadiiInterpretation majorObjectName, ObservationSite observationSite)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);
        ArgumentNullException.ThrowIfNull(observationSite);

        return Create(majorObjectName, observationSite.ID);
    }

    /// <summary>Describes the <see cref="IOrigin"/> in a query as the center of <paramref name="originObject"/>.</summary>
    /// <param name="originObject">The center of this <see cref="IOriginObject"/> represents the <see cref="IOrigin"/> in a query.</param>
    private IOrigin CreateOrigin(IOriginObject originObject) => new BodyCentricOrigin(originObject, BodyCentricComposer);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a custom <paramref name="originCoordinate"/> relative to <paramref name="originObject"/>.</summary>
    /// <param name="originObject">The <see cref="IOriginObject"/>, relative to which <paramref name="originCoordinate"/> is expressed.</param>
    /// <param name="originCoordinate">The custom <see cref="IOriginCoordinate"/>, relative to <paramref name="originObject"/>, which represents the <see cref="IOrigin"/> in a query.</param>
    private IOrigin CreateOrigin(IOriginObject originObject, IOriginCoordinate originCoordinate) => new CoordinateOrigin(originObject, originCoordinate, CoordinateComposer);

    /// <summary>Describes the <see cref="IOrigin"/> in a query as a <paramref name="observationSiteID"/> associated with <paramref name="originObject"/>.</summary>
    /// <param name="originObject">The <see cref="IOriginObject"/>, associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with <paramref name="originObject"/>.</param>
    private IOrigin CreateOrigin(IOriginObject originObject, ObservationSiteID observationSiteID) => new ObservationSiteOrigin(originObject, observationSiteID, ObservationSiteComposer);

    /// <inheritdoc cref="IOriginObjectFactory.Create(MajorObject)"/>
    private IOriginObject CreateOriginObject(MajorObject majorObject) => OriginObjectFactory.Create(majorObject);

    /// <inheritdoc cref="IOriginObjectFactory.Create(MajorObjectID)"/>
    private IOriginObject CreateOriginObject(MajorObjectID majorObjectID) => OriginObjectFactory.Create(majorObjectID);

    /// <inheritdoc cref="IOriginObjectFactory.Create(ObjectRadiiInterpretation)"/>
    private IOriginObject CreateOriginObject(ObjectRadiiInterpretation majorObjectName) => OriginObjectFactory.Create(majorObjectName);

    /// <summary>Describes the <see cref="IOriginCoordinate"/> in a query as <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate">This <see cref="CylindricalCoordinate"/> represents the <see cref="IOriginCoordinate"/> in a query.</param>
    private IOriginCoordinate CreateOriginCoordinate(CylindricalCoordinate coordinate) => CylindricalCoordinateFactory.Create(coordinate);

    /// <summary>Describes the <see cref="IOriginCoordinate"/> in a query as <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate">This <see cref="GeodeticCoordinate"/> represents the <see cref="IOriginCoordinate"/> in a query.</param>
    private IOriginCoordinate CreateOriginCoordinate(GeodeticCoordinate coordinate) => GeodeticCoordinateFactory.Create(coordinate);
}
