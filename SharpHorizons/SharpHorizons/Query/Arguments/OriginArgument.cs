namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IOriginArgument"/>
internal sealed record class OriginArgument : IOriginArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="OriginArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public OriginArgument(QueryArgument value)
    {
        Value = value;
    }
}