namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Epoch;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEphemerisEpochInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisEpochInterpreter : IEphemerisEpochInterpreter
{
    /// <inheritdoc cref="ITimeSystemOffsetProvider"/>
    private ITimeSystemOffsetProvider TimeSystemOffsetProvider { get; }

    /// <inheritdoc cref="EphemerisEpochInterpreter"/>
    /// <param name="timeSystemOffsetProvider"><inheritdoc cref="TimeSystemOffsetProvider" path="/summary"/></param>
    public EphemerisEpochInterpreter(ITimeSystemOffsetProvider timeSystemOffsetProvider)
    {
        TimeSystemOffsetProvider = timeSystemOffsetProvider;
    }

    Optional<IEpoch> IEphemerisQuantityInterpreter<IVectorsHeader, IEpoch>.Interpret(string text, IVectorsHeader header)
    {
        var equalsIndex = text.IndexOf('=', StringComparison.Ordinal);

        var idText = equalsIndex is -1 ? text : text[..equalsIndex].Trim();

        if (double.TryParse(idText, out var julianDayNumber) is false)
        {
            return new();
        }

        JulianDay julianDay = new(julianDayNumber);

        var timeSystemOffset = TimeSystemOffsetProvider.Offset(julianDay, header.TimeSystem, TimeSystem.UniversalTime);

        return julianDay + timeSystemOffset;
    }
}
