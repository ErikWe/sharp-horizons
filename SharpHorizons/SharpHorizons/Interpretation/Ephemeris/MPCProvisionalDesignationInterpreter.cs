namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed class MPCProvisionalDesignationInterpreter : IPartInterpreter<MPCProvisionalDesignation>
{
    Optional<MPCProvisionalDesignation> IPartInterpreter<MPCProvisionalDesignation>.Interpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        var startIndex = queryPart.IndexOf('(') + 1;

        if (startIndex is 0)
        {
            return new();
        }

        var stopIndex = queryPart.IndexOf(')') - 1;

        if (stopIndex is -2)
        {
            return new();
        }

        var designation = queryPart[startIndex..stopIndex];

        if (designation.Contains(' ') is false || designation.Contains('/'))
        {
            return new();
        }

        return new MPCProvisionalDesignation(designation);
    }
}
