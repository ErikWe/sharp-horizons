namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IEphemerisTypeComposer"/>
internal sealed class GenerateEphemerisComposer : IGenerateEphemerisComposer
{
    IGenerateEphemerisArgument IArgumentComposer<IGenerateEphemerisArgument, GenerateEphemeris>.Compose(GenerateEphemeris obj) => new QueryArgument(obj switch
    {
        GenerateEphemeris.Disable => "NO",
        GenerateEphemeris.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
