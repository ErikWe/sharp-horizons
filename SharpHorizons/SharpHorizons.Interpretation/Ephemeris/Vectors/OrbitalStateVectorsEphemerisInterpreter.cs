namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IOrbitalStateVectorsEphemerisInterpreter"/>
internal sealed class OrbitalStateVectorsEphemerisInterpreter : AEphemerisInterpreter<IOrbitalStateVectors, IVectorsHeader>, IOrbitalStateVectorsEphemerisInterpreter
{
    /// <inheritdoc cref="OrbitalStateVectorsEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IOrbitalStateVectorsInterpreter" path="/summary"/></param>
    public OrbitalStateVectorsEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IOrbitalStateVectorsInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IOrbitalStateVectors> IEphemerisInterpreter<IVectorsHeader, IOrbitalStateVectors>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
