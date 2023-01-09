namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IReferenceSystemComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ReferenceSystemComposer : IReferenceSystemComposer
{
    IReferenceSystemArgument IArgumentComposer<IReferenceSystemArgument, ReferenceSystem>.Compose(ReferenceSystem obj) => new QueryArgument(obj switch
    {
        ReferenceSystem.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        ReferenceSystem.ICRF => "ICRF",
        ReferenceSystem.B1950 => "B1950",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
