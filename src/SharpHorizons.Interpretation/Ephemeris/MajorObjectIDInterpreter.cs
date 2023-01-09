namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MajorObjectID"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MajorObjectIDInterpreter : IInterpreter<MajorObjectID>
{
    Optional<MajorObjectID> IInterpreter<MajorObjectID>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var startIndex = queryResult.Content.LastIndexOf('(') + 1;

        if (startIndex is 0)
        {
            return new();
        }

        if (queryResult.Content[^1] is not ')')
        {
            return new();
        }

        var idText = queryResult.Content[startIndex..^1].Trim();

        if (int.TryParse(idText, out var id) is false)
        {
            return new();
        }

        return new MajorObjectID(id);
    }
}
