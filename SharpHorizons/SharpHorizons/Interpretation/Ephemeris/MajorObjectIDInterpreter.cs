namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Identity;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MajorObjectID"/>.</summary>
internal sealed class MajorObjectIDInterpreter : IPartInterpreter<MajorObjectID>
{
    Optional<MajorObjectID> IPartInterpreter<MajorObjectID>.TryInterpret(string queryPart)
    {
        var startIndex = queryPart.LastIndexOf('(') + 1;

        if (startIndex is 0)
        {
            return new();
        }

        if (queryPart[^1] is not ')')
        {
            return new();
        }

        var idText = queryPart[startIndex..^1].Trim();

        if (int.TryParse(idText, out var id) is false)
        {
            return new();
        }

        return new MajorObjectID(id);
    }
}
