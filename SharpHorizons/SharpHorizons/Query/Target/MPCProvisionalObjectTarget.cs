namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of <see cref="MPCProvisionalObject"/>.</summary>
internal sealed record class MPCProvisionalObjectTarget : ITarget
{
    /// <summary>The <see cref="MPCProvisionalObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCProvisionalObject MPCObject { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCProvisionalObject> Composer { private get; init; }

    /// <inheritdoc cref="MPCProvisionalObjectTarget"/>
    public MPCProvisionalObjectTarget() { }

    /// <inheritdoc cref="MPCProvisionalObjectTarget"/>
    /// <param name="mpcObject"><inheritdoc cref="MPCObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCProvisionalObjectTarget(MPCProvisionalObject mpcObject, ITargetComposer<MPCProvisionalObject> composer)
    {
        MPCObject = mpcObject;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCProvisionalObject>)Composer).Compose(MPCObject);
}
