namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using SharpMeasures;

using System.Globalization;

/// <summary>Describes the <see cref="IStepSize"/> in a query using a fixed <see cref="Time"/> difference.</summary>
internal readonly record struct FixedStepSize : IStepSize
{
    /// <summary>The <see cref="Time"/> between each step. The value is rounded to an integer number of <see cref="UnitOfTime.Minute"/>.</summary>
    private Time DeltaTime { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query using a fixed <see cref="Time"/> difference <paramref name="deltaTime"/>.</summary>
    /// <param name="deltaTime"><inheritdoc cref="DeltaTime" path="/summary"/></param>
    public FixedStepSize(Time deltaTime)
    {
        DeltaTime = deltaTime;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => new StepSizeArgument($"{DeltaTime.Minutes.Round().ToString("F0", CultureInfo.InvariantCulture)}m");
}
