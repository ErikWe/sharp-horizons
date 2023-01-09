namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MajorObjectName"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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
