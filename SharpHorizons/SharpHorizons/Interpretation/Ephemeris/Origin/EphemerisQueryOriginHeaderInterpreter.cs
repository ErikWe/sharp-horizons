namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Result;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="IEphemerisQueryOriginHeaderInterpreter"/>
internal sealed class EphemerisQueryOriginHeaderInterpreter : ALineIterativeEphemerisQueryHeaderInterpreter<EphemerisQueryOriginHeaderInterpreter.MutableOriginDataInterpretation>, IEphemerisQueryOriginHeaderInterpreter
{
    /// <inheritdoc cref="EphemerisQueryOriginHeaderInterpreter"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="IInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="originInterpretationOptionsProvider"><inheritdoc cref="IOriginInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="originInterpreter"><inheritdoc cref="IOriginInterpreter" path="/summary"/>.</param>
    /// <param name="geodeticCoordinateInterpreter"><inheritdoc cref="IOriginGeodeticCoordinateInterpreter" path="/summary"/></param>
    /// <param name="cylindricalCoordinateInterpreter"><inheritdoc cref="IOriginCylindricalCoordinateInterpreter" path="/summary"/></param>
    /// <param name="referenceEllipsoidInterpreter"><inheritdoc cref="IOriginReferenceEllipsoidInterpreter" path="/summary"/></param>
    /// <param name="radiiInterpreter"><inheritdoc cref="IOriginRadiiInterpreter" path="/summary"/></param>
    public EphemerisQueryOriginHeaderInterpreter(IInterpretationOptionsProvider interpretationOptionsProvider, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IOriginInterpretationOptionsProvider originInterpretationOptionsProvider, IOriginInterpreter originInterpreter,
        IOriginGeodeticCoordinateInterpreter geodeticCoordinateInterpreter, IOriginCylindricalCoordinateInterpreter cylindricalCoordinateInterpreter, IOriginReferenceEllipsoidInterpreter referenceEllipsoidInterpreter, IOriginRadiiInterpreter radiiInterpreter)
        : base(interpretationOptionsProvider, ephemerisInterpretationOptionsProvider)
    {
        RegisterKeyInterpreter(originInterpreter, originInterpretationOptionsProvider.BodyName, static (origin, interpretation) => interpretation.Origin = origin);
        RegisterKeyInterpreter(geodeticCoordinateInterpreter, originInterpretationOptionsProvider.GeodeticCoordinate, static (target, interpretation) => interpretation.GeodeticCoordinate = target);
        RegisterKeyInterpreter(cylindricalCoordinateInterpreter, originInterpretationOptionsProvider.CylindricalCoordinate, static (target, interpretation) => interpretation.CylindricalCoordinate = target);
        RegisterKeyInterpreter(referenceEllipsoidInterpreter, originInterpretationOptionsProvider.ReferenceEllipsoid, static (referenceEllipsoid, interpretation) => interpretation.ReferenceEllipsoid = referenceEllipsoid);
        RegisterKeyInterpreter(radiiInterpreter, originInterpretationOptionsProvider.Radii, static (radii, interpretation) => interpretation.Radii = radii);
    }

    /// <summary>Registers a <see cref="IPartInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when a <paramref name="key"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when a <paramref name="key"/> is encounterd.</param>
    /// <param name="key">The key which, when encountered, results in the <paramref name="interpreter"/> being invoked.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    private void RegisterKeyInterpreter<TInterpretation>(IPartInterpreter<TInterpretation> interpreter, string key, Action<TInterpretation, MutableOriginDataInterpretation> setter)
    {
        RegisterKeyInterpreter(interpreter, key, wrapper);

        MutableOriginDataInterpretation wrapper(TInterpretation interpretation, MutableOriginDataInterpretation header)
        {
            setter(interpretation, header);

            return header;
        }
    }

    protected override Optional<MutableOriginDataInterpretation> ConstructHeader(IQueryResult _) => new MutableOriginDataInterpretation();

    protected override bool ValidateHeader(MutableOriginDataInterpretation header) => header.Origin is not null;

    Optional<IEphemerisQueryOriginHeader> IInterpreter<IEphemerisQueryOriginHeader>.TryInterpret(IQueryResult queryResult)
    {
        ArgumentNullException.ThrowIfNull(queryResult);

        var result = TryInterpret(queryResult);

        if (result.HasValue is false)
        {
            return new();
        }

        return result.Value;
    }

    /// <summary>A mutable <see cref="IEphemerisQueryOriginHeader"/>.</summary>
    public sealed class MutableOriginDataInterpretation : IEphemerisQueryOriginHeader
    {
        public IOrigin Origin { get; set; } = null!;

        public GeodeticCoordinate? GeodeticCoordinate { get; set; }
        public CylindricalCoordinate? CylindricalCoordinate { get; set; }

        public ObservationSiteName? SiteName { get; set; }

        public ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; set; }

        public ObjectRadiiInterpretation? Radii { get; set; }
    }
}
