namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as an object identified by an <see cref="MPCSequentialNumber"/>.</summary>
internal sealed record class MPCSequentialNumberTarget : ITarget
{
    /// <summary>The <see cref="MPCSequentialNumber"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCSequentialNumber Number { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCSequentialNumber> Composer { private get; init; }

    /// <inheritdoc cref="MPCSequentialNumberTarget"/>
    public MPCSequentialNumberTarget() { }

    /// <inheritdoc cref="MPCSequentialNumberTarget"/>
    /// <param name="number"><inheritdoc cref="Number" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCSequentialNumberTarget(MPCSequentialNumber number, ITargetComposer<MPCSequentialNumber> composer)
    {
        Number = number;
    
        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCSequentialNumber>)Composer).Compose(Number);
}
