namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query;

using SharpMeasures;

/// <summary>Interprets the X, Y, and Z components of an <see cref="IVelocityEphemerisEntry"/>.</summary>
internal sealed class VelocityComponentInterpreter : IVelocityXInterpreter, IVelocityYInterpreter, IVelocityZInterpreter
{
    Optional<Speed> IEphemerisQuantityInterpreter<IVectorsHeader, Speed>.Interpret(string text, IVectorsHeader header)
    {
        if (double.TryParse(text, out var value) is false || GetUnitOfSpeed(header.OutputUnits) is not UnitOfSpeed unit)
        {
            return new();
        }

        return value * unit.Speed;
    }

    /// <summary>Retrieves the <see cref="UnitOfSpeed"/> described by <paramref name="units"/>.</summary>
    /// <param name="units">The <see cref="UnitOfSpeed"/> described by this <see cref="OutputUnits"/> is retrieved.</param>
    private static UnitOfSpeed? GetUnitOfSpeed(OutputUnits units) => units switch
    {
        OutputUnits.AstronomicalUnitsAndDays => UnitOfSpeed.From(UnitOfLength.AstronomicalUnit, UnitOfTime.Day),
        OutputUnits.KilometresAndSeconds => UnitOfSpeed.From(UnitOfLength.Kilometre, UnitOfTime.Second),
        OutputUnits.KilometresAndDays => UnitOfSpeed.From(UnitOfLength.Kilometre, UnitOfTime.Day),
        _ => null
    };
}
