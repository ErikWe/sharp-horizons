namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCSequentialNumber"/>.</summary>
internal sealed class MPCSequentialNumberInterpreter : IInterpreter<MPCSequentialNumber>
{
    Optional<MPCSequentialNumber> IInterpreter<MPCSequentialNumber>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var stopIndex = queryResult.Content.IndexOf(' ') - 1;

        if (stopIndex is -2)
        {
            return new();
        }

        if (int.TryParse(queryResult.Content[..stopIndex], out var id) is false)
        {
            return new();
        }

        return new MPCSequentialNumber(id);
    }
}
