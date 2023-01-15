namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsHeaderInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class VectorsHeaderInterpreter : AEphemerisHeaderInterpreter<MutableVectorsHeader>, IVectorsHeaderInterpreter
{
    /// <inheritdoc cref="VectorsHeaderInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="targetInterpretationOptionsProvider"><inheritdoc cref="ITargetInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="originInterpretationOptionsProvider"><inheritdoc cref="IOriginInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="vectorsInterpretationOptionsProvider"><inheritdoc cref="IVectorsInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisHeaderInterpretationProvider"><inheritdoc cref="IEphemerisHeaderInterpretationProvider" path="/summary"/></param>
    /// <param name="targetHeaderInterpretationProvider"><inheritdoc cref="IEphemerisTargetHeaderInterpretationProvider" path="/summary"/></param>
    /// <param name="originHeaderInterpretationProvider"><inheritdoc cref="IEphemerisOriginHeaderInterpretationProvider" path="/summary"/></param>
    /// <param name="vectorsInterpretationProvider"><inheritdoc cref="IVectorsHeaderInterpretationProvider" path="/summary"/></param>
    public VectorsHeaderInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, ITargetInterpretationOptionsProvider targetInterpretationOptionsProvider, IOriginInterpretationOptionsProvider originInterpretationOptionsProvider,
        IVectorsInterpretationOptionsProvider vectorsInterpretationOptionsProvider, IEphemerisHeaderInterpretationProvider ephemerisHeaderInterpretationProvider, IEphemerisTargetHeaderInterpretationProvider targetHeaderInterpretationProvider,
        IEphemerisOriginHeaderInterpretationProvider originHeaderInterpretationProvider, IVectorsHeaderInterpretationProvider vectorsInterpretationProvider)
        : base(ephemerisInterpretationOptionsProvider)
    {
        RegisterFirstLineInterpreter(ephemerisHeaderInterpretationProvider.QueryEpochInterpreter, (queryTime, header) => header.QueryEpoch = queryTime);

        RegisterKeyInterpreter(targetHeaderInterpretationProvider.TargetInterpreter, targetInterpretationOptionsProvider.BodyName, (target, header) => header.TargetHeader.Target = target);
        RegisterKeyInterpreter(targetHeaderInterpretationProvider.GeodeticCoordinateInterpreter, targetInterpretationOptionsProvider.GeodeticCoordinate, static (coordinate, interpretation) => interpretation.TargetHeader.GeodeticCoordinate = coordinate);
        RegisterKeyInterpreter(targetHeaderInterpretationProvider.CylindricalCoordinateInterpreter, targetInterpretationOptionsProvider.CylindricalCoordinate, static (coordinate, interpretation) => interpretation.TargetHeader.CylindricalCoordinate = coordinate);
        RegisterKeyInterpreter(targetHeaderInterpretationProvider.ReferenceEllipsoidInterpreter, targetInterpretationOptionsProvider.ReferenceEllipsoid, static (referenceEllipsoid, interpretation) => interpretation.TargetHeader.ReferenceEllipsoid = referenceEllipsoid);
        RegisterKeyInterpreter(targetHeaderInterpretationProvider.RadiiInterpreter, targetInterpretationOptionsProvider.Radii, static (radii, interpretation) => interpretation.TargetHeader.Radii = radii);

        RegisterKeyInterpreter(originHeaderInterpretationProvider.OriginInterpreter, originInterpretationOptionsProvider.BodyName, (origin, header) => header.OriginHeader.Origin = origin);
        RegisterKeyInterpreter(originHeaderInterpretationProvider.GeodeticCoordinateInterpreter, originInterpretationOptionsProvider.GeodeticCoordinate, static (coordinate, interpretation) => interpretation.OriginHeader.GeodeticCoordinate = coordinate);
        RegisterKeyInterpreter(originHeaderInterpretationProvider.CylindricalCoordinateInterpreter, originInterpretationOptionsProvider.CylindricalCoordinate, static (coordinate, interpretation) => interpretation.OriginHeader.CylindricalCoordinate = coordinate);
        RegisterKeyInterpreter(originHeaderInterpretationProvider.SiteNameInterpreter, originInterpretationOptionsProvider.SiteName, static (siteName, header) => header.OriginHeader.SiteName = siteName);
        RegisterKeyInterpreter(originHeaderInterpretationProvider.ReferenceEllipsoidInterpreter, originInterpretationOptionsProvider.ReferenceEllipsoid, static (referenceEllipsoid, interpretation) => interpretation.OriginHeader.ReferenceEllipsoid = referenceEllipsoid);
        RegisterKeyInterpreter(originHeaderInterpretationProvider.RadiiInterpreter, originInterpretationOptionsProvider.Radii, static (radii, interpretation) => interpretation.OriginHeader.Radii = radii);

        RegisterKeyInterpreter(ephemerisHeaderInterpretationProvider.StartEpochInterpreter, ephemerisInterpretationOptionsProvider.StartEpoch, (startEpoch, header) => header.StartEpoch = startEpoch);
        RegisterKeyInterpreter(ephemerisHeaderInterpretationProvider.StopEpochInterpreter, ephemerisInterpretationOptionsProvider.StopEpoch, (stopEpoch, header) => header.StopEpoch = stopEpoch);
        RegisterKeyInterpreter(ephemerisHeaderInterpretationProvider.TimeZoneOffsetInterpreter, ephemerisInterpretationOptionsProvider.StartEpoch, (timeZoneOffset, header) => header.TimeZoneOffset = timeZoneOffset);
        RegisterKeyInterpreter(ephemerisHeaderInterpretationProvider.TimeSystemInterpreter, ephemerisInterpretationOptionsProvider.StartEpoch, (timeSystem, header) => header.TimeSystem = timeSystem);
        RegisterKeyInterpreter(ephemerisHeaderInterpretationProvider.StepSizeInterpreter, ephemerisInterpretationOptionsProvider.StepSize, (stepSize, header) => header.StepSize = stepSize);
        RegisterKeyInterpreter(ephemerisHeaderInterpretationProvider.ReferenceSystemInterpreter, ephemerisInterpretationOptionsProvider.ReferenceSystem, (referenceSystem, header) => header.ReferenceSystem = referenceSystem);

        RegisterKeyInterpreter(ephemerisHeaderInterpretationProvider.SmallPerturbersInterpreter, vectorsInterpretationOptionsProvider.SmallPerturbers, (smallPerturbers, header) => header.SmallPerturbers = smallPerturbers);

        RegisterKeyInterpreter(vectorsInterpretationProvider.ReferencePlaneInterpreter, vectorsInterpretationOptionsProvider.ReferencePlane, (referencePlane, header) => header.ReferencePlane = referencePlane);

        RegisterKeyInterpreter(vectorsInterpretationProvider.OutputUnitsInterpreter, vectorsInterpretationOptionsProvider.OutputUnits, (outputUnits, header) => header.OutputUnits = outputUnits);
        RegisterKeyInterpreter(vectorsInterpretationProvider.CorrectionInterpreter, vectorsInterpretationOptionsProvider.VectorCorrection, (correction, header) => header.Correction = correction);
        RegisterKeyInterpreter(vectorsInterpretationProvider.TableContentInterpreter, vectorsInterpretationOptionsProvider.VectorTableContent, (tableContent, header) => header.TableContent = tableContent);
    }

    /// <summary>Registers a <see cref="IInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when the first line of the ephemeris is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when the first line of the ephemeris is encounterd.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    private void RegisterFirstLineInterpreter<TInterpretation>(IInterpreter<TInterpretation> interpreter, Action<TInterpretation, MutableVectorsHeader> setter)
    {
        RegisterFirstLineInterpreter(interpreter, wrapper);

        MutableVectorsHeader wrapper(TInterpretation interpretation, MutableVectorsHeader header)
        {
            setter(interpretation, header);

            return header;
        }
    }

    /// <summary>Registers a <see cref="IInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when a <paramref name="key"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when a <paramref name="key"/> is encounterd.</param>
    /// <param name="key">The key which, when encountered, results in the <paramref name="interpreter"/> being invoked.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    private void RegisterKeyInterpreter<TInterpretation>(IInterpreter<TInterpretation> interpreter, string key, Action<TInterpretation, MutableVectorsHeader> setter)
    {
        RegisterKeyInterpreter(interpreter, key, wrapper);

        MutableVectorsHeader wrapper(TInterpretation interpretation, MutableVectorsHeader header)
        {
            setter(interpretation, header);

            return header;
        }
    }

    protected override Optional<MutableVectorsHeader> ConstructHeader(QueryResult queryResult) => new MutableVectorsHeader();

    protected override MutableVectorsHeader SetQuantities(MutableVectorsHeader header, EphemerisQuantityTable quantities)
    {
        header.Quantities = quantities;

        return header;
    }

    protected override bool ValidateHeader(MutableVectorsHeader header) => MutableVectorsHeader.Validate(header);

    Optional<IVectorsHeader> IInterpreter<IVectorsHeader>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (Interpret(queryResult) is not { HasValue: true, Value: var interpretation })
        {
            return new();
        }

        return interpretation;
    }
}
