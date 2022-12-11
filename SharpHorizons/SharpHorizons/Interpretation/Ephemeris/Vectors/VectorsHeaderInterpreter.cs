namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using SharpMeasures;

using System;

/// <inheritdoc cref="IVectorsHeaderInterpreter"/>
internal sealed class VectorsHeaderInterpreter : ALineIterativeEphemerisHeaderInterpreter<VectorsHeaderInterpreter.MutableVectorsQueryHeader>, IVectorsHeaderInterpreter
{
    /// <inheritdoc cref="IEphemerisTargetHeaderInterpreter"/>
    private IEphemerisTargetHeaderInterpreter TargetHeaderInterpreter { get; }

    /// <inheritdoc cref="IEphemerisOriginHeaderInterpreter"/>
    private IEphemerisOriginHeaderInterpreter OriginHeaderInterpreter { get; }

    /// <inheritdoc cref="VectorsHeaderInterpreter"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="IVectorsInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="targetHeaderInterpreter"><inheritdoc cref="TargetHeaderInterpreter" path="/summary"/></param>
    /// <param name="originHeaderInterpreter"><inheritdoc cref="OriginHeaderInterpreter" path="/summary"/></param>
    /// <param name="queryTimeInterpreter"><inheritdoc cref="IEphemerisQueryEpochInterpreter" path="/summary"/></param>
    /// <param name="startEpochInterpreter"><inheritdoc cref="IEphemerisStartEpochInterpreter" path="/summary"/></param>
    /// <param name="stopEpochInterpreter"><inheritdoc cref="IEphemerisStopEpochInterpreter" path="/summary"/></param>
    /// <param name="timeZoneOffsetInterpreter"><inheritdoc cref="ITimeZoneOffsetInterpreter" path="/summary"/></param>
    /// <param name="timeSystemInterpreter"><inheritdoc cref="ITimeSystemInterpreter" path="/summary"/></param>
    /// <param name="stepSizeInterpreter"><inheritdoc cref="IEphemerisStepSizeInterpreter" path="/summary"/></param>
    /// <param name="smallPerturbersInterpreter"><inheritdoc cref="ISmallPerturbersInterpreter" path="/summary"/></param>
    /// <param name="outputUnitsInterpreter"><inheritdoc cref="IOutputUnitsInterpreter" path="/summary"/></param>
    /// <param name="referenceSystemInterpreter"><inheritdoc cref="IReferenceSystemInterpreter" path="/summary"/></param>
    /// <param name="referencePlaneInterpreter"><inheritdoc cref="IReferencePlaneInterpreter" path="/summary"/></param>
    /// <param name="correctionInterpreter"><inheritdoc cref="IVectorCorrectionInterpreter" path="/summary"/></param>
    /// <param name="tableContentInterpreter"><inheritdoc cref="IVectorTableContentInterpreter" path="/summary"/></param>
    public VectorsHeaderInterpreter(IVectorsInterpretationOptionsProvider interpretationOptionsProvider, IEphemerisTargetHeaderInterpreter targetHeaderInterpreter, IEphemerisOriginHeaderInterpreter originHeaderInterpreter, IEphemerisQueryEpochInterpreter queryTimeInterpreter, IEphemerisStartEpochInterpreter startEpochInterpreter,
        IEphemerisStopEpochInterpreter stopEpochInterpreter, ITimeZoneOffsetInterpreter timeZoneOffsetInterpreter, ITimeSystemInterpreter timeSystemInterpreter, IEphemerisStepSizeInterpreter stepSizeInterpreter, ISmallPerturbersInterpreter smallPerturbersInterpreter, IOutputUnitsInterpreter outputUnitsInterpreter,
        IReferenceSystemInterpreter referenceSystemInterpreter, IReferencePlaneInterpreter referencePlaneInterpreter, IVectorCorrectionInterpreter correctionInterpreter, IVectorTableContentInterpreter tableContentInterpreter)
        : base(interpretationOptionsProvider)
    {
        TargetHeaderInterpreter = targetHeaderInterpreter;
        OriginHeaderInterpreter = originHeaderInterpreter;

        RegisterFirstLineInterpreter(queryTimeInterpreter, (queryTime, header) => header.QueryTime = queryTime);
        RegisterKeyInterpreter(startEpochInterpreter, interpretationOptionsProvider.StartEpoch, (startEpoch, header) => header.StartEpoch = startEpoch);
        RegisterKeyInterpreter(stopEpochInterpreter, interpretationOptionsProvider.StopEpoch, (stopEpoch, header) => header.StopEpoch = stopEpoch);
        RegisterKeyInterpreter(timeZoneOffsetInterpreter, interpretationOptionsProvider.StartEpoch, (timeZoneOffset, header) => header.TimeZoneOffset = timeZoneOffset);
        RegisterKeyInterpreter(timeSystemInterpreter, interpretationOptionsProvider.StartEpoch, (timeSystem, header) => header.TimeSystem = timeSystem);
        RegisterKeyInterpreter(stepSizeInterpreter, interpretationOptionsProvider.StepSize, (stepSize, header) => header.StepSize = stepSize);

        foreach (var smallPerturbersKey in interpretationOptionsProvider.SmallPerturbers)
        {
            RegisterKeyInterpreter(smallPerturbersInterpreter, smallPerturbersKey, (smallPerturbers, header) => header.SmallPerturbers = smallPerturbers);
        }

        RegisterKeyInterpreter(referenceSystemInterpreter, interpretationOptionsProvider.ReferenceSystem, (referenceSystem, header) => header.ReferenceSystem = referenceSystem);
        RegisterKeyInterpreter(referencePlaneInterpreter, interpretationOptionsProvider.ReferencePlane, (referencePlane, header) => header.ReferencePlane = referencePlane);

        RegisterKeyInterpreter(outputUnitsInterpreter, interpretationOptionsProvider.OutputUnits, (outputUnits, header) => header.OutputUnits = outputUnits);
        RegisterKeyInterpreter(correctionInterpreter, interpretationOptionsProvider.VectorCorrection, (correction, header) => header.Correction = correction);
        RegisterKeyInterpreter(tableContentInterpreter, interpretationOptionsProvider.VectorTableContent, (tableContent, header) => header.TableContent = tableContent);
    }

    /// <summary>Registers a <see cref="IPartInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when the first line of the ephemeris is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when the first line of the ephemeris is encounterd.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    private void RegisterFirstLineInterpreter<TInterpretation>(IPartInterpreter<TInterpretation> interpreter, Action<TInterpretation, MutableVectorsQueryHeader> setter)
    {
        RegisterFirstLineInterpreter(interpreter, wrapper);

        MutableVectorsQueryHeader wrapper(TInterpretation interpretation, MutableVectorsQueryHeader header)
        {
            setter(interpretation, header);

            return header;
        }
    }

    /// <summary>Registers a <see cref="IPartInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when a <paramref name="key"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when a <paramref name="key"/> is encounterd.</param>
    /// <param name="key">The key which, when encountered, results in the <paramref name="interpreter"/> being invoked.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    private void RegisterKeyInterpreter<TInterpretation>(IPartInterpreter<TInterpretation> interpreter, string key, Action<TInterpretation, MutableVectorsQueryHeader> setter)
    {
        RegisterKeyInterpreter(interpreter, key, wrapper);

        MutableVectorsQueryHeader wrapper(TInterpretation interpretation, MutableVectorsQueryHeader header)
        {
            setter(interpretation, header);

            return header;
        }
    }

    protected override Optional<MutableVectorsQueryHeader> ConstructHeader(IQueryResult queryResult)
    {
        if (TargetHeaderInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var target } || OriginHeaderInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var origin })
        {
            return new();
        }

        return new MutableVectorsQueryHeader(target, origin);
    }

    protected override bool ValidateHeader(MutableVectorsQueryHeader header) => header.QueryTime is not null && header.StartEpoch is not null && header.StopEpoch is not null;

    Optional<IVectorsHeader> IInterpreter<IVectorsHeader>.Interpret(IQueryResult queryResult)
    {
        ArgumentNullException.ThrowIfNull(queryResult);

        if (Interpret(queryResult) is not { HasValue: true, Value: var interpretation })
        {
            return new();
        }

        return interpretation;
    }

    /// <summary>A mutable <see cref="IVectorsHeader"/>.</summary>
    public sealed class MutableVectorsQueryHeader : IVectorsHeader
    {
        public IEpoch QueryTime { get; set; } = null!;
        
        public IEphemerisTargetHeader TargetHeader { get; }
        public IEphemerisOriginHeader OriginHeader { get; }

        public IEpoch StartEpoch { get; set; } = null!;
        public IEpoch StopEpoch { get; set; } = null!;
        public IStepSize? StepSize { get; set; }

        public TimeSystem TimeSystem { get; set; }
        public Time TimeZoneOffset { get; set; }

        public bool SmallPerturbers { get; set; }

        public OutputUnits OutputUnits { get; set; }
        public VectorCorrection Correction { get; set; }
        public VectorTableContent TableContent { get; set; }
        public ReferencePlane ReferencePlane { get; set; }
        public ReferenceSystem ReferenceSystem { get; set; }

        /// <inheritdoc cref="MutableVectorsQueryHeader"/>
        /// <param name="targetHeader"><inheritdoc cref="TargetHeader" path="/summary"/></param>
        /// <param name="originHeader"><inheritdoc cref="OriginHeader" path="/summary"/></param>
        public MutableVectorsQueryHeader(IEphemerisTargetHeader targetHeader, IEphemerisOriginHeader originHeader)
        {
            TargetHeader = targetHeader;
            OriginHeader = originHeader;
        }
    }
}
