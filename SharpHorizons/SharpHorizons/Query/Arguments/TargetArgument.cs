namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="ITargetArgument"/>
internal sealed record class TargetArgument : ITargetArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="TargetArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public TargetArgument(QueryArgument value)
    {
        Value = value;
    }
}