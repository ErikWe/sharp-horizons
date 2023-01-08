namespace SharpHorizons.Interpretation.Ephemeris;

/// <summary>Provides the <see cref="IInterpreter{TInterpretation}"/> related to interpreting an <see cref="IEphemerisHeader"/>.</summary>
public interface IEphemerisHeaderInterpretationProvider
{
    /// <inheritdoc cref="IEphemerisQueryEpochInterpreter"/>
    public abstract IEphemerisQueryEpochInterpreter QueryEpochInterpreter { get; }

    /// <inheritdoc cref="IEphemerisStartEpochInterpreter"/>
    public abstract IEphemerisStartEpochInterpreter StartEpochInterpreter { get; }

    /// <inheritdoc cref="IEphemerisStopEpochInterpreter"/>
    public abstract IEphemerisStopEpochInterpreter StopEpochInterpreter { get; }

    /// <inheritdoc cref="IEphemerisStepSizeInterpreter"/>
    public abstract IEphemerisStepSizeInterpreter StepSizeInterpreter { get; }

    /// <inheritdoc cref="ITimeSystemInterpreter"/>
    public abstract ITimeSystemInterpreter TimeSystemInterpreter { get; }

    /// <inheritdoc cref="ITimeZoneOffsetInterpreter"/>
    public abstract ITimeZoneOffsetInterpreter TimeZoneOffsetInterpreter { get; }

    /// <inheritdoc cref="ISmallPerturbersInterpreter"/>
    public abstract ISmallPerturbersInterpreter SmallPerturbersInterpreter { get; }

    /// <inheritdoc cref="IReferenceSystemInterpreter"/>
    public abstract IReferenceSystemInterpreter ReferenceSystemInterpreter { get; }
}
