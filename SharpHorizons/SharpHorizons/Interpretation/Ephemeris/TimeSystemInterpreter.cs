namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="ITimeSystemInterpreter"/>
internal sealed class TimeSystemInterpreter : ITimeSystemInterpreter
{
    Optional<TimeSystem> IInterpreter<TimeSystem>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':');

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryResult.Content[(firstColonIndex + 1)..].Trim().Split(' ', System.StringSplitOptions.RemoveEmptyEntries) is not { Length: 4 } spaceSplit)
        {
            return new();
        }

        var timeSystemString = spaceSplit[3];

        if (timeSystemString.StartsWith("UT"))
        {
            return TimeSystem.UT;
        }

        if (timeSystemString.StartsWith("TT"))
        {
            return TimeSystem.TT;
        }

        if (timeSystemString.StartsWith("TDB"))
        {
            return TimeSystem.TDB;
        }

        return new();
    }
}
