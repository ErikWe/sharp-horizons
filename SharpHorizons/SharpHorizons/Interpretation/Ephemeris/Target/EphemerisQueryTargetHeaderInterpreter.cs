namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <inheritdoc cref="IEphemerisQueryTargetHeaderInterpreter"/>
internal sealed class EphemerisQueryTargetHeaderInterpreter : ALineIterativeEphemerisQueryHeaderInterpreter<EphemerisQueryTargetHeaderInterpreter.MutableTargetDataInterpretation>, IEphemerisQueryTargetHeaderInterpreter
{
    /// <inheritdoc cref="EphemerisQueryTargetHeaderInterpreter"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="IInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="targetInterpretationOptionsProvider"><inheritdoc cref="ITargetInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="targetInterpreter"><inheritdoc cref="ITargetInterpreter" path="/summary"/></param>
    /// <param name="geodeticCoordinateInterpreter"><inheritdoc cref="ITargetGeodeticCoordinateInterpreter" path="/summary"/></param>
    /// <param name="cylindricalCoordinateInterpreter"><inheritdoc cref="ITargetCylindricalCoordinateInterpreter" path="/summary"/></param>
    /// <param name="referenceEllipsoidInterpreter"><inheritdoc cref="ITargetReferenceEllipsoidInterpreter" path="/summary"/></param>
    /// <param name="radiiInterpreter"><inheritdoc cref="ITargetRadiiInterpreter" path="/summary"/></param>
    public EphemerisQueryTargetHeaderInterpreter(IInterpretationOptionsProvider interpretationOptionsProvider, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, ITargetInterpretationOptionsProvider targetInterpretationOptionsProvider, ITargetInterpreter targetInterpreter,
        ITargetGeodeticCoordinateInterpreter geodeticCoordinateInterpreter, ITargetCylindricalCoordinateInterpreter cylindricalCoordinateInterpreter, ITargetReferenceEllipsoidInterpreter referenceEllipsoidInterpreter, ITargetRadiiInterpreter radiiInterpreter)
        : base(interpretationOptionsProvider, ephemerisInterpretationOptionsProvider)
    {
        RegisterKeyInterpreter(targetInterpreter, targetInterpretationOptionsProvider.BodyName, static (target, interpretation) => interpretation.Target = target);
        RegisterKeyInterpreter(geodeticCoordinateInterpreter, targetInterpretationOptionsProvider.GeodeticCoordinate, static (target, interpretation) => interpretation.GeodeticCoordinate = target);
        RegisterKeyInterpreter(cylindricalCoordinateInterpreter, targetInterpretationOptionsProvider.CylindricalCoordinate, static (target, interpretation) => interpretation.CylindricalCoordinate = target);
        RegisterKeyInterpreter(referenceEllipsoidInterpreter, targetInterpretationOptionsProvider.ReferenceEllipsoid, static (referenceEllipsoid, interpretation) => interpretation.ReferenceEllipsoid = referenceEllipsoid);
        RegisterKeyInterpreter(radiiInterpreter, targetInterpretationOptionsProvider.Radii, static (radii, interpretation) => interpretation.Radii = radii);
    }

    /// <summary>Registers a <see cref="IPartInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when a <paramref name="key"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when a <paramref name="key"/> is encounterd.</param>
    /// <param name="key">The key which, when encountered, results in the <paramref name="interpreter"/> being invoked.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    private void RegisterKeyInterpreter<TInterpretation>(IPartInterpreter<TInterpretation> interpreter, string key, Action<TInterpretation, MutableTargetDataInterpretation> setter)
    {
        RegisterKeyInterpreter(interpreter, key, wrapper);

        MutableTargetDataInterpretation wrapper(TInterpretation interpretation, MutableTargetDataInterpretation header)
        {
            setter(interpretation, header);

            return header;
        }
    }

    protected override Optional<MutableTargetDataInterpretation> ConstructHeader(IQueryResult _) => new MutableTargetDataInterpretation();

    protected override bool ValidateHeader(MutableTargetDataInterpretation header) => header.Target is not null;

    Optional<IEphemerisQueryTargetHeader> IInterpreter<IEphemerisQueryTargetHeader>.TryInterpret(IQueryResult queryResult)
    {
        ArgumentNullException.ThrowIfNull(queryResult);

        var result = TryInterpret(queryResult);

        if (result.HasValue is false)
        {
            return new();
        }

        return result.Value;
    }

    /// <summary>A mutable <see cref="IEphemerisQueryTargetHeader"/>.</summary>
    public sealed class MutableTargetDataInterpretation : IEphemerisQueryTargetHeader
    {
        public ITarget Target { get; set; } = null!;

        public GeodeticCoordinate? GeodeticCoordinate { get; set; }
        public CylindricalCoordinate? CylindricalCoordinate { get; set; }

        public ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; set; }

        public ObjectRadiiInterpretation? Radii { get; set; }
    }
}
