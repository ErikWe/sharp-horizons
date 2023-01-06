namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IReferenceSystemInterpreter"/>
internal sealed class ReferenceSystemInterpreter : IReferenceSystemInterpreter
{
    Optional<ReferenceSystem> IInterpreter<ReferenceSystem>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Contains("J2000") || queryResult.Content.Contains("ICRF"))
        {
            return ReferenceSystem.ICRF;
        }

        if (queryResult.Content.Contains("B1950") || queryResult.Content.Contains("FK4"))
        {
            return ReferenceSystem.B1950;
        }

        return new();
    }
}
