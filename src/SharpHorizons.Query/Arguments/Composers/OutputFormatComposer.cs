namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IOutputFormatComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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
