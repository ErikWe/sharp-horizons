namespace SharpHorizons.Query.Epoch;

/// <summary>Describes the <see cref="IStepSize"/> in a query using an <see cref="int"/> number of uniformly distributed steps.</summary>
public interface IUniformStepSize : IStepSize
{
    /// <summary>The total number of steps.</summary>
    /// <remarks>As the <see cref="IStartEpoch"/> is not considered a step, the number of <see cref="IEpoch"/> in an <see cref="IEpochRange"/> would be { <see cref="StepCount"/> + 1 }.</remarks>
    public abstract int StepCount { get; }
}
