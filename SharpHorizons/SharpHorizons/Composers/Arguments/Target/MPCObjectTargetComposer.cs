namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identification;

using System;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCObject"/>.</summary>
internal sealed class MPCObjectTargetComposer : ITargetComposer<MPCObject>
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
    private ITargetComposer<MPCSequentialNumber> SequentialNumberComposer { get; }

    /// <summary><inheritdoc cref="MPCObjectTargetComposer" path="/summary"/></summary>
    /// <param name="sequentialNumberComposer"><inheritdoc cref="SequentialNumberComposer" path="/summary"/></param>
    public MPCObjectTargetComposer(ITargetComposer<MPCSequentialNumber> sequentialNumberComposer)
    {
        SequentialNumberComposer = sequentialNumberComposer;
    }

    ITargetArgument IArgumentComposer<ITargetArgument, MPCObject>.Compose(MPCObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return SequentialNumberComposer.Compose(obj.SequentialNumber);
    }
}
