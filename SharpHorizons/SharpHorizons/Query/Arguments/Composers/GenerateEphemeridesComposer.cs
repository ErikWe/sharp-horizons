namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IEphemerisTypeComposer"/>
internal sealed class GenerateEphemeridesComposer : IGenerateEphemeridesComposer
{
    IGenerateEphemeridesArgument IArgumentComposer<IGenerateEphemeridesArgument, GenerateEphemerides>.Compose(GenerateEphemerides obj) => new QueryArgument(obj switch
    {
        GenerateEphemerides.Disable => "NO",
        GenerateEphemerides.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
