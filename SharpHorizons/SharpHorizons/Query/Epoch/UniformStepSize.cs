namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using SharpMeasures;

using System.Globalization;

/// <summary>Describes the <see cref="IStepSize"/> in a query using a total number of steps, uniformly distributed between the start and end epoch.</summary>
internal readonly record struct UniformStepSize : IStepSize
{
    /// <summary>The total number of steps.</summary>
    private int StepCount { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query using a total of <paramref name="stepCount"/> steps, uniformly distributed between the start and end epoch.</summary>
    /// <param name="stepCount"><inheritdoc cref="StepCount" path="/summary"/></param>
    public UniformStepSize(int stepCount)
    {
        StepCount = stepCount;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => new StepSizeArgument(StepCount.ToString(CultureInfo.InvariantCulture));
}
