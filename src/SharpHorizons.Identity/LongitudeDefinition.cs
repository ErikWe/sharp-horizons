namespace SharpHorizons;

/// <summary>Describes how longitude is defined.</summary>
public enum LongitudeDefinition
{
    /// <summary>The <see cref="LongitudeDefinition"/> is not known.</summary>
    Unknown,
    /// <summary>Longitude is defined as positive to the west.</summary>
    WestPositive,
    /// <summary>Longitude is defined as positive to the east.</summary>
    EastPositive
}
