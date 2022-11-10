namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;
using System.ComponentModel;

/// <inheritdoc cref="IEphemerisTypeComposer"/>
internal sealed class GenerateEphemeridesComposer : IGenerateEphemeridesComposer
{
    IGenerateEphemeridesArgument IArgumentComposer<IGenerateEphemeridesArgument, GenerateEphemerides>.Compose(GenerateEphemerides obj) => new QueryArgument(obj switch
    {
        GenerateEphemerides.Disable => "NO",
        GenerateEphemerides.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(GenerateEphemerides))
    });
}
