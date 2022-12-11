namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IOrbitalStateVectorsInterpreter"/>
internal sealed class OrbitalStateVectorsInterpreter : IOrbitalStateVectorsInterpreter
{
    /// <inheritdoc cref="IVectorsHeaderInterpreter"/>
    private IVectorsHeaderInterpreter HeaderInterpreter { get; }

    /// <inheritdoc cref="OrbitalStateVectorsInterpreter"/>
    /// <param name="headerInterpreter"><inheritdoc cref="IVectorsHeaderInterpreter" path="/summary"/></param>
    public OrbitalStateVectorsInterpreter(IVectorsHeaderInterpreter headerInterpreter)
    {
        HeaderInterpreter = headerInterpreter;
    }

    Optional<IOrbitalStateVectorsEphemeris> IInterpreter<IOrbitalStateVectorsEphemeris>.Interpret(IQueryResult queryResult)
    {
        var _ = HeaderInterpreter.Interpret(queryResult);

        throw new System.Exception();
    }
}
