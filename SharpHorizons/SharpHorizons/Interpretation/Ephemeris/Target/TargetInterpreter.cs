namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.CodeAnalysis;

using SharpHorizons.Identity;
using SharpHorizons.Query.Target;

/// <inheritdoc cref="ITargetInterpreter"/>
internal sealed class TargetInterpreter : ITargetInterpreter
{
    /// <inheritdoc cref="ITargetFactory"/>
    private ITargetFactory TargetFactory { get; }

    /// <inheritdoc cref="Ephemeris.MajorObjectInterpreter"/>
    public IPartInterpreter<MajorObject> MajorObjectInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCProvisionalObjectInterpreter"/>
    public IPartInterpreter<MPCProvisionalObject> MPCProvisionalObjectInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCObjectInterpreter"/>
    public IPartInterpreter<MPCObject> MPCObjectInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCCometInterpreter"/>
    public IPartInterpreter<MPCComet> MPCCometInterpreter { get; }

    /// <inheritdoc cref="TargetInterpreter"/>
    /// <param name="targetFactory"><inheritdoc cref="TargetFactory" path="/summary"/></param>
    /// <param name="majorObjectInterpreter"><inheritdoc cref="MajorObjectInterpreter" path="/summary"/></param>
    /// <param name="mpcProvisionalObjectInterpreter"><inheritdoc cref="MPCProvisionalObjectInterpreter" path="/summary"/></param>
    /// <param name="mpcObjectInterpreter"><inheritdoc cref="MPCObjectInterpreter" path="/summary"/></param>
    /// <param name="mpcCometInterpreter"><inheritdoc cref="MPCCometInterpreter" path="/summary"/></param>
    public TargetInterpreter(ITargetFactory targetFactory, IPartInterpreter<MajorObject> majorObjectInterpreter, IPartInterpreter<MPCProvisionalObject> mpcProvisionalObjectInterpreter, IPartInterpreter<MPCObject> mpcObjectInterpreter, IPartInterpreter<MPCComet> mpcCometInterpreter)
    {
        TargetFactory = targetFactory;

        MajorObjectInterpreter = majorObjectInterpreter;
        MPCProvisionalObjectInterpreter = mpcProvisionalObjectInterpreter;
        MPCObjectInterpreter = mpcObjectInterpreter;
        MPCCometInterpreter = mpcCometInterpreter;
    }

    Optional<ITarget> IPartInterpreter<ITarget>.TryInterpret(string queryPart)
    {
        if (queryPart.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } bracketSplit)
        {
            return new();
        }

        var identifier = bracketSplit[0].Trim();

        if (MajorObjectInterpreter.TryInterpret(identifier) is { HasValue: true, Value: var majorObject })
        {
            return new(TargetFactory.Create(majorObject));
        }

        if (MPCProvisionalObjectInterpreter.TryInterpret(identifier) is { HasValue: true, Value: var mpcProvisionalObject })
        {
            return new(TargetFactory.Create(mpcProvisionalObject));
        }

        if (MPCObjectInterpreter.TryInterpret(identifier) is { HasValue: true, Value: var mpcObject })
        {
            return new(TargetFactory.Create(mpcObject));
        }

        if (MPCCometInterpreter.TryInterpret(identifier) is { HasValue: true, Value: var mpcComet })
        {
            return new(TargetFactory.Create(mpcComet));
        }

        return new();
    }
}
