namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

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
