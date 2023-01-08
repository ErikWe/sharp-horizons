namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed class MPCProvisionalDesignationInterpreter : IInterpreter<MPCProvisionalDesignation>
{
    Optional<MPCProvisionalDesignation> IInterpreter<MPCProvisionalDesignation>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var startIndex = queryResult.Content.IndexOf('(') + 1;

        if (startIndex is 0)
        {
            return new();
        }

        var stopIndex = queryResult.Content.IndexOf(')') - 1;

        if (stopIndex is -2)
        {
            return new();
        }

        var designation = queryResult.Content[startIndex..stopIndex].Trim();

        if (designation.Contains(' ') is false || designation.Contains('/'))
        {
            return new();
        }

        return new MPCProvisionalDesignation(designation);
    }
}
