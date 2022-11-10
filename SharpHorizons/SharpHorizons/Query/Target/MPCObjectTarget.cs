namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an <see cref="Identity.MPCObject"/>.</summary>
internal sealed record class MPCObjectTarget : ITarget
{
    /// <summary>The <see cref="Identity.MPCObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCObject MPCObject { get; }

    /// <summary>Used to compose a <see cref="ICommandArgument"/> describing <see langword="this"/>.</summary>
    private ICommandComposer<MPCObject> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject"><inheritdoc cref="MPCObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MPCObjectTarget(MPCObject mpcObject, ICommandComposer<MPCObject> composer)
    {
        MPCObject = mpcObject;

        Composer = composer;
    }

    ICommandArgument ITarget.ComposeArgument() => Composer.Compose(MPCObject);
}
