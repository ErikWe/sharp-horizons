namespace SharpHorizons.Composers.Arguments;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="IVectorLabelsComposer"/>
internal sealed class OutputLabelsComposer : IElementLabelsComposer, IVectorLabelsComposer
{
    IElementLabelsArgument IArgumentComposer<IElementLabelsArgument, OutputLabels>.Compose(OutputLabels obj) => new QueryArgument(Compose(obj));
    IVectorLabelsArgument IArgumentComposer<IVectorLabelsArgument, OutputLabels>.Compose(OutputLabels obj) => new QueryArgument(Compose(obj));

    /// <summary>Composes a <see cref="string"/> describing <paramref name="outputLabels"/>.</summary>
    /// <param name="outputLabels">The composed <see cref="string"/> describes this <see cref="OutputLabels"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"></exception>
    private static string Compose(OutputLabels outputLabels) => outputLabels switch
    {
        OutputLabels.Disable => "NO",
        OutputLabels.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(outputLabels), (int)outputLabels, typeof(OutputLabels))
    };
}
