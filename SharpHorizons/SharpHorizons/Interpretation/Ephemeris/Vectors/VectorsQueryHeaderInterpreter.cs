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

/// <inheritdoc cref="IVectorsQueryHeaderInterpreter"/>
internal sealed class VectorsQueryHeaderInterpreter : ALineIterativeEphemerisQueryHeaderInterpreter<VectorsQueryHeaderInterpreter.MutableVectorsQueryHeader>, IVectorsQueryHeaderInterpreter
{
    /// <inheritdoc cref="IEphemerisQueryTargetHeaderInterpreter"/>
    private IEphemerisQueryTargetHeaderInterpreter TargetHeaderInterpreter { get; }

    /// <inheritdoc cref="IEphemerisQueryOriginHeaderInterpreter"/>
    private IEphemerisQueryOriginHeaderInterpreter OriginHeaderInterpreter { get; }

    /// <inheritdoc cref="VectorsQueryHeaderInterpreter"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="IInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="targetHeaderInterpreter"><inheritdoc cref="TargetHeaderInterpreter" path="/summary"/></param>
    /// <param name="originHeaderInterpreter"><inheritdoc cref="OriginHeaderInterpreter" path="/summary"/></param>
    /// <param name="queryTimeInterpreter"><inheritdoc cref="IEphemerisQueryEpochInterpreter" path="/summary"/></param>
    public VectorsQueryHeaderInterpreter(IInterpretationOptionsProvider interpretationOptionsProvider, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisQueryTargetHeaderInterpreter targetHeaderInterpreter, IEphemerisQueryOriginHeaderInterpreter originHeaderInterpreter,
        IEphemerisQueryEpochInterpreter queryTimeInterpreter)
        : base(interpretationOptionsProvider, ephemerisInterpretationOptionsProvider)
    {
        TargetHeaderInterpreter = targetHeaderInterpreter;
        OriginHeaderInterpreter = originHeaderInterpreter;

        RegisterFirstLineInterpreter(queryTimeInterpreter, (queryTime, header) => header.QueryTime = queryTime);
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

    Optional<IVectorsQueryHeader> IInterpreter<IVectorsQueryHeader>.Interpret(IQueryResult queryResult)
    {
        ArgumentNullException.ThrowIfNull(queryResult);

        if (Interpret(queryResult) is not { HasValue: true, Value: var interpretation })
        {
            return new();
        }

        return interpretation;
    }

    /// <summary>A mutable <see cref="IVectorsQueryHeader"/>.</summary>
    public sealed class MutableVectorsQueryHeader : IVectorsQueryHeader
    {
        public IEpoch QueryTime { get; set; } = null!;
        
        public IEphemerisQueryTargetHeader TargetHeader { get; }
        public IEphemerisQueryOriginHeader OriginHeader { get; }

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

        /// <inheritdoc cref="MutableVectorsQueryHeader"/>
        /// <param name="targetHeader"><inheritdoc cref="TargetHeader" path="/summary"/></param>
        /// <param name="originHeader"><inheritdoc cref="OriginHeader" path="/summary"/></param>
        public MutableVectorsQueryHeader(IEphemerisQueryTargetHeader targetHeader, IEphemerisQueryOriginHeader originHeader)
        {
            TargetHeader = targetHeader;
            OriginHeader = originHeader;
        }
    }
}
