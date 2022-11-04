namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using System;
using System.Globalization;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IFixedStepSize"/>.</summary>
internal sealed class FixedStepSizeComposer : IStepSizeComposer<IFixedStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, IFixedStepSize>.Compose(IFixedStepSize obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"{obj.DeltaTime.Minutes.Round().ToString("F0", CultureInfo.InvariantCulture)}m");
    }
}
