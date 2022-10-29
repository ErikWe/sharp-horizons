namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IStepSizeArgument"/>
internal sealed record class StepSizeArgument : IStepSizeArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary>Uses { <paramref name="value"/> } to describe the step size in a query.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public StepSizeArgument(QueryArgument value)
    {
        Value = value;
    }
}