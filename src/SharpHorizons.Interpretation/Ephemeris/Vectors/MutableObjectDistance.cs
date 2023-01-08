namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>A mutable <see cref="IObjectDistance"/>.</summary>
internal sealed record class MutableObjectDistance : IObjectDistance
{
    public IEpoch Epoch { get; set; } = null!;

    /// <inheritdoc cref="IObjectDistance.Distance"/>
    public Distance? Distance { get; set; }

    /// <inheritdoc cref="IObjectDistance.RadialSpeed"/>
    public Speed? RadialSpeed { get; set; }

    /// <inheritdoc cref="IObjectDistance.LightTime"/>
    public Time? LightTime { get; set; }

    Distance IObjectDistance.Distance => Distance!.Value;
    Speed IObjectDistance.RadialSpeed => RadialSpeed!.Value;
    Time IObjectDistance.LightTime => LightTime!.Value;

    /// <summary>Determines the validity of the <see cref="MutableObjectDistance"/> <paramref name="ephemerisEntry"/>.</summary>
    /// <param name="ephemerisEntry">This <see cref="MutableObjectDistance"/> is validated.</param>
    public static bool Validate(MutableObjectDistance ephemerisEntry) => ephemerisEntry.Epoch is not null && ephemerisEntry.Distance is not null && ephemerisEntry.RadialSpeed is not null && ephemerisEntry.LightTime is not null;
}
