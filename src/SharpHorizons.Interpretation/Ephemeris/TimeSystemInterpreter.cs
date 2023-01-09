namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITimeSystemInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class TimeSystemInterpreter : ITimeSystemInterpreter
{
    Optional<TimeSystem> IInterpreter<TimeSystem>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':', StringComparison.Ordinal);

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryResult.Content[(firstColonIndex + 1)..].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries) is not { Length: 4 } spaceSplit)
        {
            return new();
        }

        var timeSystemString = spaceSplit[3];

        if (timeSystemString.StartsWith("UT", StringComparison.Ordinal))
        {
            return TimeSystem.UT;
        }

        if (timeSystemString.StartsWith("TT", StringComparison.Ordinal))
        {
            return TimeSystem.TT;
        }

        if (timeSystemString.StartsWith("TDB", StringComparison.Ordinal))
        {
            return TimeSystem.TDB;
        }

        return new();
    }
}
