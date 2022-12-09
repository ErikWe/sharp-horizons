namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MajorObjectName"/>.</summary>
internal sealed class MajorObjectNameInterpreter : IPartInterpreter<MajorObjectName>
{
    Optional<MajorObjectName> IPartInterpreter<MajorObjectName>.Interpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        var lastIndex = queryPart.LastIndexOf('(');

        var name = queryPart[..lastIndex].Trim();

        if (int.TryParse(name, out var _))
        {
            return new();
        }

        return new MajorObjectName(name);
    }
}
