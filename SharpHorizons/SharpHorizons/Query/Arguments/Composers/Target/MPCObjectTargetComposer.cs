namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

using System;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCObject"/>.</summary>
internal sealed class MPCObjectTargetComposer : ITargetComposer<MPCObject>
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
    private ITargetComposer<MPCSequentialNumber> SequentialNumberComposer { get; }

    /// <inheritdoc cref="MPCObjectTargetComposer"/>
    /// <param name="sequentialNumberComposer"><inheritdoc cref="SequentialNumberComposer" path="/summary"/></param>
    public MPCObjectTargetComposer(ITargetComposer<MPCSequentialNumber> sequentialNumberComposer)
    {
        SequentialNumberComposer = sequentialNumberComposer;
    }

    ITargetArgument IArgumentComposer<ITargetArgument, MPCObject>.Compose(MPCObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return ((IArgumentComposer<ITargetArgument, MPCSequentialNumber>)SequentialNumberComposer).Compose(obj.SequentialNumber);
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCObject>.Compose(MPCObject obj) => ((IArgumentComposer<ITargetArgument, MPCObject>)this).Compose(obj);
}
