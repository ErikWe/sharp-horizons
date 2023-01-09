namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorLabelsComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class OutputLabelsComposer : IVectorLabelsComposer
{
    IVectorLabelsArgument IArgumentComposer<IVectorLabelsArgument, OutputLabels>.Compose(OutputLabels obj) => new QueryArgument(obj switch
    {
        OutputLabels.Disable => "NO",
        OutputLabels.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
