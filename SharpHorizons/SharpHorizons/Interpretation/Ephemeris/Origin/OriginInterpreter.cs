namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Origin;

using System;

/// <inheritdoc cref="IOriginInterpreter"/>
internal sealed class OriginInterpreter : IOriginInterpreter
{
    /// <inheritdoc cref="IOriginFactory"/>
    private IOriginFactory OriginFactory { get; }

    /// <inheritdoc cref="Ephemeris.MajorObjectInterpreter"/>
    public IPartInterpreter<MajorObject> MajorObjectInterpreter { get; }

    /// <inheritdoc cref="OriginInterpreter"/>
    /// <param name="originFactory"><inheritdoc cref="OriginFactory" path="/summary"/></param>
    /// <param name="majorObjectInterpreter"><inheritdoc cref="MajorObjectInterpreter" path="/summary"/></param>
    public OriginInterpreter(IOriginFactory originFactory, IPartInterpreter<MajorObject> majorObjectInterpreter)
    {
        OriginFactory = originFactory;

        MajorObjectInterpreter = majorObjectInterpreter;
    }

    Optional<IOrigin> IPartInterpreter<IOrigin>.Interpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        if (queryPart.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } bracketSplit)
        {
            return new();
        }

        var identifier = bracketSplit[0].Trim();

        if (MajorObjectInterpreter.Interpret(identifier) is { HasValue: true, Value: var majorObject })
        {
            return new(OriginFactory.Create(majorObject));
        }

        return new();
    }
}
