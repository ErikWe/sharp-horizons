namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEphemerisTypeComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisTypeComposer : IEphemerisTypeComposer
{
    IEphemerisTypeArgument IArgumentComposer<IEphemerisTypeArgument, EphemerisType>.Compose(EphemerisType obj) => new QueryArgument(obj switch
    {
        EphemerisType.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        EphemerisType.Observables => "O",
        EphemerisType.Vectors => "V",
        EphemerisType.Elements => "E",
        EphemerisType.CloseApproach => "A",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
