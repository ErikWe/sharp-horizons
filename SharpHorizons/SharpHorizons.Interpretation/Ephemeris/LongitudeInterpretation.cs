namespace SharpHorizons.Interpretation.Ephemeris;

/// <summary>Describes how longitude is interpreted.</summary>
public enum LongitudeInterpretation
{
    /// <summary>The <see cref="LongitudeInterpretation"/> is not known.</summary>
    Unknown,
    /// <summary>Longitude is positive to the west.</summary>
    WestPositive,
    /// <summary>Longitude is positive to the east.</summary>
    EastPositive
}
