﻿namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCName"/>.</summary>
internal sealed class MPCNameInterpreter : IPartInterpreter<MPCName>
{
    Optional<MPCName> IPartInterpreter<MPCName>.Interpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        if (queryPart.Split('(') is not { Length: > 1 } parenthesisSplit)
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