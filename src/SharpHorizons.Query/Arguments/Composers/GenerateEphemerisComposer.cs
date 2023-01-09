namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEphemerisTypeComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class GenerateEphemerisComposer : IGenerateEphemerisComposer
{
    IGenerateEphemerisArgument IArgumentComposer<IGenerateEphemerisArgument, GenerateEphemeris>.Compose(GenerateEphemeris obj) => new QueryArgument(obj switch
    {
        GenerateEphemeris.Disable => "NO",
        GenerateEphemeris.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
