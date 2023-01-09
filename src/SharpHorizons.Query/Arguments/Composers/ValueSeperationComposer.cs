namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IValueSeparationComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ValueSeperationComposer : IValueSeparationComposer
{
    IValueSeparationArgument IArgumentComposer<IValueSeparationArgument, ValueSeparation>.Compose(ValueSeparation obj) => new QueryArgument(obj switch
    {
        ValueSeparation.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        ValueSeparation.CommaSeparation => "YES",
        ValueSeparation.WhitespaceSeparation => "NO",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
