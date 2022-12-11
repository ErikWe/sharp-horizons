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
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="IOriginInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="originInterpreter"><inheritdoc cref="IOriginInterpreter" path="/summary"/>.</param>
    /// <param name="geodeticCoordinateInterpreter"><inheritdoc cref="IOriginGeodeticCoordinateInterpreter" path="/summary"/></param>
    /// <param name="cylindricalCoordinateInterpreter"><inheritdoc cref="IOriginCylindricalCoordinateInterpreter" path="/summary"/></param>
    /// <param name="referenceEllipsoidInterpreter"><inheritdoc cref="IOriginReferenceEllipsoidInterpreter" path="/summary"/></param>
    /// <param name="radiiInterpreter"><inheritdoc cref="IOriginRadiiInterpreter" path="/summary"/></param>
    public EphemerisQueryOriginHeaderInterpreter(IOriginInterpretationOptionsProvider interpretationOptionsProvider, IOriginInterpreter originInterpreter, IOriginGeodeticCoordinateInterpreter geodeticCoordinateInterpreter,
        IOriginCylindricalCoordinateInterpreter cylindricalCoordinateInterpreter, IOriginReferenceEllipsoidInterpreter referenceEllipsoidInterpreter, IOriginRadiiInterpreter radiiInterpreter)
        : base(interpretationOptionsProvider)
    {
        RegisterKeyInterpreter(originInterpreter, interpretationOptionsProvider.BodyName, static (origin, interpretation) => interpretation.Origin = origin);
        RegisterKeyInterpreter(geodeticCoordinateInterpreter, interpretationOptionsProvider.GeodeticCoordinate, static (target, interpretation) => interpretation.GeodeticCoordinate = target);
        RegisterKeyInterpreter(cylindricalCoordinateInterpreter, interpretationOptionsProvider.CylindricalCoordinate, static (target, interpretation) => interpretation.CylindricalCoordinate = target);
        RegisterKeyInterpreter(referenceEllipsoidInterpreter, interpretationOptionsProvider.ReferenceEllipsoid, static (referenceEllipsoid, interpretation) => interpretation.ReferenceEllipsoid = referenceEllipsoid);
        RegisterKeyInterpreter(radiiInterpreter, interpretationOptionsProvider.Radii, static (radii, interpretation) => interpretation.Radii = radii);
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

    Optional<IEphemerisQueryOriginHeader> IInterpreter<IEphemerisQueryOriginHeader>.Interpret(IQueryResult queryResult)
    {
        ArgumentNullException.ThrowIfNull(queryResult);

        if (Interpret(queryResult) is not { HasValue: true, Value: var interpretation })
        {
            return new();
        }

        return interpretation;
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
