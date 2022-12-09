namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IOutputFormatComposer"/>
internal sealed class OutputFormatComposer : IOutputFormatComposer
{
    IOutputFormatArgument IArgumentComposer<IOutputFormatArgument, OutputFormat>.Compose(OutputFormat obj) => new QueryArgument(obj switch
    {
        OutputFormat.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        OutputFormat.Text => "text",
        OutputFormat.JSON => "json",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
