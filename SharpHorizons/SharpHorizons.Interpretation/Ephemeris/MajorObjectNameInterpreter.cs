namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MajorObjectName"/>.</summary>
internal sealed class MajorObjectNameInterpreter : IInterpreter<MajorObjectName>
{
    Optional<MajorObjectName> IInterpreter<MajorObjectName>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var lastIndex = queryResult.Content.LastIndexOf('(');

        var name = queryResult.Content[..lastIndex].Trim();

        if (int.TryParse(name, out var _))
        {
            return new();
        }

        return new MajorObjectName(name);
    }
}
