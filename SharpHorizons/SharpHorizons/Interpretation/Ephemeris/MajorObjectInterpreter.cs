namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Identity;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MajorObject"/>.</summary>
internal sealed class MajorObjectInterpreter : IPartInterpreter<MajorObject>
{
    /// <inheritdoc cref="Ephemeris.MajorObjectIDInterpreter"/>
    private IPartInterpreter<MajorObjectID> MajorObjectIDInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MajorObjectNameInterpreter"/>
    private IPartInterpreter<MajorObjectName> MajorObjectNameInterpreter { get; }

    /// <inheritdoc cref="MajorObjectInterpreter"/>
    /// <param name="majorObjectIDInterpreter"><inheritdoc cref="MajorObjectIDInterpreter" path="/summary"/></param>
    /// <param name="majorObjectNameInterpreter"><inheritdoc cref="MajorObjectNameInterpreter" path="/summary"/></param>
    public MajorObjectInterpreter(IPartInterpreter<MajorObjectID> majorObjectIDInterpreter, IPartInterpreter<MajorObjectName> majorObjectNameInterpreter)
    {
        MajorObjectIDInterpreter = majorObjectIDInterpreter;
        MajorObjectNameInterpreter = majorObjectNameInterpreter;
    }

    Optional<MajorObject> IPartInterpreter<MajorObject>.TryInterpret(string queryPart)
    {
        if (MajorObjectIDInterpreter.TryInterpret(queryPart) is not { HasValue: true, Value: var id })
        {
            return new();
        }

        if (MajorObjectNameInterpreter.TryInterpret(queryPart) is not { HasValue: true, Value: var name })
        {
            return new MajorObject(id);
        }

        return new MajorObject(id, name);
    }
}
