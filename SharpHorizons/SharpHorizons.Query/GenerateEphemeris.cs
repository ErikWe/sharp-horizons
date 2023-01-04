namespace SharpHorizons.Query;

using SharpHorizons.Ephemeris;

/// <summary>Specifies whether an <see cref="IEphemeris{TEntry}"/> is generated.</summary>
public enum GenerateEphemeris
{
    /// <summary>An <see cref="IEphemeris{TEntry}"/> is not generated.</summary>
    Disable,
    /// <summary>An <see cref="IEphemeris{TEntry}"/> is generated.</summary>
    Enable
}
