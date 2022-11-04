namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using System;
using System.Globalization;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IUniformStepSize"/>.</summary>
internal sealed class UniformStepSizeComposer : IStepSizeComposer<IUniformStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, IUniformStepSize>.Compose(IUniformStepSize stepSize)
    {
        ArgumentNullException.ThrowIfNull(stepSize);

        return new QueryArgument(stepSize.StepCount.ToString(CultureInfo.InvariantCulture));
    }
}
