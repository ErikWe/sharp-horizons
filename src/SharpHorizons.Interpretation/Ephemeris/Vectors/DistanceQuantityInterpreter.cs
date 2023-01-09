namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Query;

using SharpMeasures;

using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets a <see cref="Distance"/> of some <see cref="IVectorsEphemerisEntry"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class DistanceQuantityInterpreter : IObjectPositionComponentInterpreter, IDistanceInterpreter, IObjectPositionUncertaintyACNComponentInterpreter, IObjectPositionUncertaintyPOSComponentInterpreter, IObjectPositionUncertaintyRTNComponentInterpreter, IObjectPositionUncertaintyXYZComponentInterpreter
{
    Optional<Distance> IEphemerisQuantityInterpreter<IVectorsHeader, Distance>.Interpret(string text, IVectorsHeader header)
    {
        if (double.TryParse(text, out var value) is false || GetUnitOfLength(header.OutputUnits) is not UnitOfLength unit)
        {
            return new();
        }

        return value * unit.Distance;
    }

    /// <summary>Retrieves the <see cref="UnitOfLength"/> described by <paramref name="units"/>.</summary>
    /// <param name="units">The <see cref="UnitOfLength"/> described by this <see cref="OutputUnits"/> is retrieved.</param>
    private static UnitOfLength? GetUnitOfLength(OutputUnits units) => units switch
    {
        OutputUnits.AstronomicalUnitsAndDays => UnitOfLength.AstronomicalUnit,
        OutputUnits.KilometresAndSeconds or OutputUnits.KilometresAndDays => UnitOfLength.Kilometre,
        _ => null
    };
}
