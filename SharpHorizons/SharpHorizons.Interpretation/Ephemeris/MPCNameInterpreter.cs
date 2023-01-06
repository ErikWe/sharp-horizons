namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCName"/>.</summary>
internal sealed class MPCNameInterpreter : IInterpreter<MPCName>
{
    Optional<MPCName> IInterpreter<MPCName>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Split('(') is not { Length: > 1 } parenthesisSplit)
        {
            return new();
        }

        var numberAndName = parenthesisSplit[0].TrimStart();

        var startIndex = numberAndName.IndexOf(' ') + 1;

        if (startIndex is 0)
        {
            return new();
        }

        return new MPCName(numberAndName[startIndex..].Trim());
    }
}
