namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;
using SharpHorizons.Query.Target;

using System;

/// <inheritdoc cref="ITargetInterpreter"/>
internal sealed class TargetInterpreter : ITargetInterpreter
{
    /// <inheritdoc cref="ITargetFactory"/>
    private ITargetFactory TargetFactory { get; }

    /// <inheritdoc cref="Ephemeris.MajorObjectInterpreter"/>
    public IInterpreter<MajorObject> MajorObjectInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCProvisionalObjectInterpreter"/>
    public IInterpreter<MPCProvisionalObject> MPCProvisionalObjectInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCObjectInterpreter"/>
    public IInterpreter<MPCObject> MPCObjectInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCCometInterpreter"/>
    public IInterpreter<MPCComet> MPCCometInterpreter { get; }

    /// <inheritdoc cref="TargetInterpreter"/>
    /// <param name="targetFactory"><inheritdoc cref="TargetFactory" path="/summary"/></param>
    /// <param name="majorObjectInterpreter"><inheritdoc cref="MajorObjectInterpreter" path="/summary"/></param>
    /// <param name="mpcProvisionalObjectInterpreter"><inheritdoc cref="MPCProvisionalObjectInterpreter" path="/summary"/></param>
    /// <param name="mpcObjectInterpreter"><inheritdoc cref="MPCObjectInterpreter" path="/summary"/></param>
    /// <param name="mpcCometInterpreter"><inheritdoc cref="MPCCometInterpreter" path="/summary"/></param>
    public TargetInterpreter(ITargetFactory targetFactory, IInterpreter<MajorObject> majorObjectInterpreter, IInterpreter<MPCProvisionalObject> mpcProvisionalObjectInterpreter, IInterpreter<MPCObject> mpcObjectInterpreter, IInterpreter<MPCComet> mpcCometInterpreter)
    {
        TargetFactory = targetFactory;

        MajorObjectInterpreter = majorObjectInterpreter;
        MPCProvisionalObjectInterpreter = mpcProvisionalObjectInterpreter;
        MPCObjectInterpreter = mpcObjectInterpreter;
        MPCCometInterpreter = mpcCometInterpreter;
    }

    Optional<ITarget> IInterpreter<ITarget>.Interpret(QueryResult queryResult)
    {
        ArgumentNullException.ThrowIfNull(queryResult);

        if (queryResult.Content.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } bracketSplit)
        {
            return new();
        }

        var identifier = bracketSplit[0].Trim();

        QueryResult queryResultPart = new(queryResult.Signature, identifier);

        if (MajorObjectInterpreter.Interpret(queryResultPart) is { HasValue: true, Value: var majorObject })
        {
            return new(TargetFactory.Create(majorObject));
        }

        if (MPCProvisionalObjectInterpreter.Interpret(queryResultPart) is { HasValue: true, Value: var mpcProvisionalObject })
        {
            return new(TargetFactory.Create(mpcProvisionalObject));
        }

        if (MPCObjectInterpreter.Interpret(queryResultPart) is { HasValue: true, Value: var mpcObject })
        {
            return new(TargetFactory.Create(mpcObject));
        }

        if (MPCCometInterpreter.Interpret(queryResultPart) is { HasValue: true, Value: var mpcComet })
        {
            return new(TargetFactory.Create(mpcComet));
        }

        return new();
    }
}
