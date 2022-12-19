namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <inheritdoc cref="IObjectDistance"/>
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

    /// <summary>Validates that <paramref name="vectors"/> represents a valid <see cref="IObjectDistance"/>.</summary>
    /// <param name="vectors">This <see cref="IObjectDistance"/> is validated.</param>
    public static bool Validate(MutableObjectDistance vectors) => vectors.Epoch is not null && vectors.Distance is not null && vectors.RadialSpeed is not null && vectors.LightTime is not null;
}
