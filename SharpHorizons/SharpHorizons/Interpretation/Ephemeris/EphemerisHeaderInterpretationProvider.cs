namespace SharpHorizons.Interpretation.Ephemeris;

/// <inheritdoc cref="IEphemerisHeaderInterpretationProvider"/>
internal sealed class EphemerisHeaderInterpretationProvider : IEphemerisHeaderInterpretationProvider
{
    public IEphemerisQueryEpochInterpreter QueryEpochInterpreter { get; private init; }
    public IEphemerisStartEpochInterpreter StartEpochInterpreter { get; private init; }
    public IEphemerisStopEpochInterpreter StopEpochInterpreter { get; private init; }
    public IEphemerisStepSizeInterpreter StepSizeInterpreter { get; private init; }
    public ITimeSystemInterpreter TimeSystemInterpreter { get; private init; }
    public ITimeZoneOffsetInterpreter TimeZoneOffsetInterpreter { get; private init; }
    public ISmallPerturbersInterpreter SmallPerturbersInterpreter { get; private init; }
    public IReferenceSystemInterpreter ReferenceSystemInterpreter { get; private init; }

    /// <inheritdoc cref="EphemerisHeaderInterpretationProvider"/>
    /// <param name="queryEpochInterpreter"><inheritdoc cref="QueryEpochInterpreter" path="/summary"/></param>
    /// <param name="startEpochInterpreter"><inheritdoc cref="StartEpochInterpreter" path="/summary"/></param>
    /// <param name="stopEpochInterpreter"><inheritdoc cref="StopEpochInterpreter" path="/summary"/></param>
    /// <param name="stepSizeInterpreter"><inheritdoc cref="StepSizeInterpreter" path="/summary"/></param>
    /// <param name="timeSystemInterpreter"><inheritdoc cref="TimeSystemInterpreter" path="/summary"/></param>
    /// <param name="timeZoneOffsetInterpreter"><inheritdoc cref="TimeZoneOffsetInterpreter" path="/summary"/></param>
    /// <param name="smallPerturbersInterpreter"><inheritdoc cref="SmallPerturbersInterpreter" path="/summary"/></param>
    /// <param name="referenceSystemInterpreter"><inheritdoc cref="ReferenceSystemInterpreter" path="/summary"/></param>
    public EphemerisHeaderInterpretationProvider(IEphemerisQueryEpochInterpreter queryEpochInterpreter, IEphemerisStartEpochInterpreter startEpochInterpreter, IEphemerisStopEpochInterpreter stopEpochInterpreter, IEphemerisStepSizeInterpreter stepSizeInterpreter,
        ITimeSystemInterpreter timeSystemInterpreter, ITimeZoneOffsetInterpreter timeZoneOffsetInterpreter, ISmallPerturbersInterpreter smallPerturbersInterpreter, IReferenceSystemInterpreter referenceSystemInterpreter)
    {
        QueryEpochInterpreter = queryEpochInterpreter;
        StartEpochInterpreter = startEpochInterpreter;
        StopEpochInterpreter = stopEpochInterpreter;
        StepSizeInterpreter = stepSizeInterpreter;
        TimeSystemInterpreter = timeSystemInterpreter;
        TimeZoneOffsetInterpreter = timeZoneOffsetInterpreter;
        SmallPerturbersInterpreter = smallPerturbersInterpreter;
        ReferenceSystemInterpreter = referenceSystemInterpreter;
    }
}
