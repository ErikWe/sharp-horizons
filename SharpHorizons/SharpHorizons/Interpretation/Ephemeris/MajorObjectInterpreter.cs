namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MajorObject"/>.</summary>
internal sealed class MajorObjectInterpreter : IPartInterpreter<MajorObject>
{
    /// <inheritdoc cref="Ephemeris.MajorObjectIDInterpreter"/>
    private IPartInterpreter<MajorObjectID> MajorObjectIDInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MajorObjectNameInterpreter"/>
    private IPartInterpreter<SharpHorizons.ObjectRadiiInterpretation> MajorObjectNameInterpreter { get; }

    /// <inheritdoc cref="MajorObjectInterpreter"/>
    /// <param name="majorObjectIDInterpreter"><inheritdoc cref="MajorObjectIDInterpreter" path="/summary"/></param>
    /// <param name="majorObjectNameInterpreter"><inheritdoc cref="MajorObjectNameInterpreter" path="/summary"/></param>
    public MajorObjectInterpreter(IPartInterpreter<MajorObjectID> majorObjectIDInterpreter, IPartInterpreter<SharpHorizons.ObjectRadiiInterpretation> majorObjectNameInterpreter)
    {
        MajorObjectIDInterpreter = majorObjectIDInterpreter;
        MajorObjectNameInterpreter = majorObjectNameInterpreter;
    }

    Optional<MajorObject> IPartInterpreter<MajorObject>.TryInterpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

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
