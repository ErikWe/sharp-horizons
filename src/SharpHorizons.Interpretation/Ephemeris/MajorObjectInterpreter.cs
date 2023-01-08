namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MajorObject"/>.</summary>
internal sealed class MajorObjectInterpreter : IInterpreter<MajorObject>
{
    /// <inheritdoc cref="Ephemeris.MajorObjectIDInterpreter"/>
    private IInterpreter<MajorObjectID> MajorObjectIDInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MajorObjectNameInterpreter"/>
    private IInterpreter<MajorObjectName> MajorObjectNameInterpreter { get; }

    /// <inheritdoc cref="MajorObjectInterpreter"/>
    /// <param name="majorObjectIDInterpreter"><inheritdoc cref="MajorObjectIDInterpreter" path="/summary"/></param>
    /// <param name="majorObjectNameInterpreter"><inheritdoc cref="MajorObjectNameInterpreter" path="/summary"/></param>
    public MajorObjectInterpreter(IInterpreter<MajorObjectID> majorObjectIDInterpreter, IInterpreter<MajorObjectName> majorObjectNameInterpreter)
    {
        MajorObjectIDInterpreter = majorObjectIDInterpreter;
        MajorObjectNameInterpreter = majorObjectNameInterpreter;
    }

    Optional<MajorObject> IInterpreter<MajorObject>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (MajorObjectIDInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var id })
        {
            return new();
        }

        if (MajorObjectNameInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var name })
        {
            return new MajorObject(id);
        }

        return new MajorObject(id, name);
    }
}
