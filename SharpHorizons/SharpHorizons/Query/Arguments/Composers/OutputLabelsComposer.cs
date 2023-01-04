namespace SharpHorizons.Query.Arguments.Composers;

using System.ComponentModel;

/// <inheritdoc cref="IVectorLabelsComposer"/>
internal sealed class OutputLabelsComposer : IVectorLabelsComposer
{
    IVectorLabelsArgument IArgumentComposer<IVectorLabelsArgument, OutputLabels>.Compose(OutputLabels obj) => new QueryArgument(Compose(obj));

    /// <summary>Composes a <see cref="string"/> describing <paramref name="outputLabels"/>.</summary>
    /// <param name="outputLabels">The composed <see cref="string"/> describes this <see cref="OutputLabels"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static string Compose(OutputLabels outputLabels) => outputLabels switch
    {
        OutputLabels.Disable => "NO",
        OutputLabels.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(outputLabels)
    };
}
