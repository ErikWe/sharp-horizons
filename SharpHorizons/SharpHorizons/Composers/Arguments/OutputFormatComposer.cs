namespace SharpHorizons.Composers.Arguments;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="IOutputFormatComposer"/>
internal sealed class OutputFormatComposer : IOutputFormatComposer
{
    IOutputFormatArgument IArgumentComposer<IOutputFormatArgument, OutputFormat>.Compose(OutputFormat obj) => new QueryArgument(obj switch
    {
        OutputFormat.Text => "text",
        OutputFormat.JSON => "json",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(OutputFormat))
    });
}
