namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using SharpMeasures;

using System.Globalization;

/// <summary>Describes the <see cref="IStepSize"/> in a query as the variable amount of time it takes for the position of a <see cref="ITarget"/> to change by a certain <see cref="Angle"/>, as seen from an <see cref="IOrigin"/>.</summary>
internal readonly record struct AngularStepSize : IStepSize
{
    /// <summary>The change in position of a <see cref="ITarget"/> between each step. The value is rounded to an integer number of <see cref="UnitOfAngle.Arcsecond"/>.</summary>
    private Angle DeltaAngle { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query as the variable amount of time it takes for the position of a <see cref="ITarget"/> to change by <paramref name="deltaAngle"/>, as seen from an <see cref="IOrigin"/>.</summary>
    /// <param name="deltaAngle"><inheritdoc cref="DeltaAngle" path="/summary"/></param>
    public AngularStepSize(Angle deltaAngle)
    {
        DeltaAngle = deltaAngle;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => new StepSizeArgument($"VAR{DeltaAngle.Arcseconds.Round().ToString("F0", CultureInfo.InvariantCulture)}");
}
