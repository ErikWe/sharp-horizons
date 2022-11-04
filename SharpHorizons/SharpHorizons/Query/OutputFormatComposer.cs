namespace SharpHorizons.Query;

using SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IOutputFormatComposer"/>
internal sealed class OutputFormatComposer : IOutputFormatComposer
{
    IOutputFormatArgument IArgumentComposer<IOutputFormatArgument, OutputFormat>.Compose(OutputFormat obj) => new QueryArgument(obj switch
    {
        OutputFormat.CommaSeparation => "YES",
        OutputFormat.WhitespaceSeparation => "NO",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(OutputFormat))
    });
}
