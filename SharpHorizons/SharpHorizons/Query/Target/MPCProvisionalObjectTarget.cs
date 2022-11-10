namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of <see cref="MPCProvisionalObject"/>.</summary>
internal sealed record class MPCProvisionalObjectTarget : ITarget
{
    /// <summary>The <see cref="MPCProvisionalObject"/>, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCProvisionalObject MPCObject { get; }

    /// <summary>Used to compose a <see cref="ICommandArgument"/> describing <see langword="this"/>.</summary>
    private ICommandComposer<MPCProvisionalObject> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject"><inheritdoc cref="MPCObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MPCProvisionalObjectTarget(MPCProvisionalObject mpcObject, ICommandComposer<MPCProvisionalObject> composer)
    {
        MPCObject = mpcObject;

        Composer = composer;
    }

    ICommandArgument ITarget.ComposeArgument() => Composer.Compose(MPCObject);
}
