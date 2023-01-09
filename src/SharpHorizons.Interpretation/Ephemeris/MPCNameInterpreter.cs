namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCName"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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

        var startIndex = numberAndName.IndexOf(' ', StringComparison.Ordinal) + 1;

        if (startIndex is 0)
        {
            return new();
        }

        return new MPCName(numberAndName[startIndex..].Trim());
    }
}
