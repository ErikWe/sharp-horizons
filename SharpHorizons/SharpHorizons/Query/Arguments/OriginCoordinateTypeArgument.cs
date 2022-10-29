namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IOriginCoordinateTypeArgument"/>
internal sealed record class OriginCoordinateTypeArgument : IOriginCoordinateTypeArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="OriginCoordinateTypeArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public OriginCoordinateTypeArgument(QueryArgument value)
    {
        Value = value;
    }
}