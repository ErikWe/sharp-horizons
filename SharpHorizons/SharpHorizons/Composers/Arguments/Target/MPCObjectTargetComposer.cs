namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query;

using System;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCObject"/>.</summary>
internal sealed class MPCObjectTargetComposer : ICommandComposer<MPCObject>
{
    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
    private ICommandComposer<MPCSequentialNumber> SequentialNumberComposer { get; }

    /// <summary><inheritdoc cref="MPCObjectTargetComposer" path="/summary"/></summary>
    /// <param name="sequentialNumberComposer"><inheritdoc cref="SequentialNumberComposer" path="/summary"/></param>
    public MPCObjectTargetComposer(ICommandComposer<MPCSequentialNumber> sequentialNumberComposer)
    {
        SequentialNumberComposer = sequentialNumberComposer;
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCObject>.Compose(MPCObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return SequentialNumberComposer.Compose(obj.SequentialNumber);
    }
}
