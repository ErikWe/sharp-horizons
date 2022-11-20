namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an <see cref="Identity.MPCObject"/>.</summary>
internal sealed record class MPCObjectTarget : ITarget
{
    /// <summary>The <see cref="Identity.MPCObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCObject MPCObject { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCObject> Composer { private get; init; }

    /// <inheritdoc cref="MPCObjectTarget"/>
    public MPCObjectTarget() { }

    /// <inheritdoc cref="MPCObjectTarget"/>
    /// <param name="mpcObject"><inheritdoc cref="MPCObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCObjectTarget(MPCObject mpcObject, ITargetComposer<MPCObject> composer)
    {
        MPCObject = mpcObject;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCObject>)Composer).Compose(MPCObject);
}
