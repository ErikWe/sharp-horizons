namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Query;

using SharpMeasures;

/// <summary>Interprets a <see cref="Time"/> of some <see cref="IVectorsEphemerisEntry"/>.</summary>
internal sealed class TimeQuantityInterpreter : ILightTimeInterpreter
{
    Optional<Time> IEphemerisQuantityInterpreter<IVectorsHeader, Time>.Interpret(string text, IVectorsHeader header)
    {
        if (double.TryParse(text, out var value) is false || GetUnitOfTime(header.OutputUnits) is not UnitOfTime unit)
        {
            return new();
        }

        return value * unit.Time;
    }

    /// <summary>Retrieves the <see cref="UnitOfTime"/> described by <paramref name="units"/>.</summary>
    /// <param name="units">The <see cref="UnitOfTime"/> described by this <see cref="OutputUnits"/> is retrieved.</param>
    private static UnitOfTime? GetUnitOfTime(OutputUnits units) => units switch
    {
        OutputUnits.AstronomicalUnitsAndDays or OutputUnits.KilometresAndDays => UnitOfTime.Day,
        OutputUnits.KilometresAndSeconds => UnitOfTime.Second,
        _ => null
    };
}
