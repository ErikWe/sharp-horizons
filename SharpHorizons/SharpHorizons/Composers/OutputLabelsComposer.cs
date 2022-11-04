namespace SharpHorizons.Composers;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="IOutputLabelsComposer"/>
internal sealed class OutputLabelsComposer : IOutputLabelsComposer
{
    IOutputLabelsArgument IArgumentComposer<IOutputLabelsArgument, OutputLabels>.Compose(OutputLabels obj) => new QueryArgument(obj switch
    {
        OutputLabels.Disable => "NO",
        OutputLabels.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(OutputLabels))
    });
}
