namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IReferenceSystemInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ReferenceSystemInterpreter : IReferenceSystemInterpreter
{
    Optional<ReferenceSystem> IInterpreter<ReferenceSystem>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Contains("J2000", StringComparison.Ordinal) || queryResult.Content.Contains("ICRF", StringComparison.Ordinal))
        {
            return ReferenceSystem.ICRF;
        }

        if (queryResult.Content.Contains("B1950", StringComparison.Ordinal) || queryResult.Content.Contains("FK4", StringComparison.Ordinal))
        {
            return ReferenceSystem.B1950;
        }

        return new();
    }
}
