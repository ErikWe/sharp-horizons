namespace SharpHorizons.Interpretation.Ephemeris;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEphemerisHeaderInterpretationProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisHeaderInterpretationProvider : IEphemerisHeaderInterpretationProvider
{
    public IEphemerisQueryEpochInterpreter QueryEpochInterpreter { get; }
    public IEphemerisStartEpochInterpreter StartEpochInterpreter { get; }
    public IEphemerisStopEpochInterpreter StopEpochInterpreter { get; }
    public IEphemerisStepSizeInterpreter StepSizeInterpreter { get; }
    public ITimeSystemInterpreter TimeSystemInterpreter { get; }
    public ITimeZoneOffsetInterpreter TimeZoneOffsetInterpreter { get; }
    public ISmallPerturbersInterpreter SmallPerturbersInterpreter { get; }
    public IReferenceSystemInterpreter ReferenceSystemInterpreter { get; }

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
