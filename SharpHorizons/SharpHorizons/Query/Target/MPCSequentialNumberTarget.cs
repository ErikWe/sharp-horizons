namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers.Arguments;
using SharpHorizons.Identity;

/// <summary>Describes the <see cref="ITarget"/> in a query as an object identified by an <see cref="MPCSequentialNumber"/>.</summary>
internal sealed record class MPCSequentialNumberTarget : ITarget
{
    /// <summary>The <see cref="MPCSequentialNumber"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCSequentialNumber Number { get; }

    /// <summary>Used to compose a <see cref="ICommandArgument"/> describing <see langword="this"/>.</summary>
    private ICommandComposer<MPCSequentialNumber> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as an object identified by <paramref name="number"/>.</summary>
    /// <param name="number"><inheritdoc cref="Number" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MPCSequentialNumberTarget(MPCSequentialNumber number, ICommandComposer<MPCSequentialNumber> composer)
    {
        Number = number;
    
        Composer = composer;
    }

    ICommandArgument ITarget.ComposeArgument() => Composer.Compose(Number);
}
