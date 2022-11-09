namespace SharpHorizons.Query.Epoch;

/// <summary>Describes the <see cref="IStepSize"/> in a query using an <see cref="int"/> number of uniformly distributed steps.</summary>
public interface IUniformStepSize : IStepSize
{
    /// <summary>The total number of steps.</summary>
    public abstract int StepCount { get; }
}
