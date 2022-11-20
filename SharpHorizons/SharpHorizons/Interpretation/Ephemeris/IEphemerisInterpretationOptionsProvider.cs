namespace SharpHorizons.Interpretation.Ephemeris;

/// <summary>Provides options for how the result of an ephemeris query is interpreted.</summary>
public interface IEphemerisInterpretationOptionsProvider
{
    /// <inheritdoc cref="EphemerisInterpretationOptions.EphemerisDataStart"/>
    public abstract string EphemerisDataStart { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.EphemerisDataBlockCount"/>
    public abstract int EphemerisDataBlockCount { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.WestPositiveLongitude"/>
    public abstract string WestPositiveLongitude { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.EastPositiveLongitude"/>
    public abstract string EastPositiveLongitude { get; }
}
