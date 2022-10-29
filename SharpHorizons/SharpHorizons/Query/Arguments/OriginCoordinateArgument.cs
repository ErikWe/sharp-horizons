namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IOriginCoordinateArgument"/>
internal sealed record class OriginCoordinateArgument : IOriginCoordinateArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="OriginCoordinateArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public OriginCoordinateArgument(QueryArgument value)
    {
        Value = value;
    }
}