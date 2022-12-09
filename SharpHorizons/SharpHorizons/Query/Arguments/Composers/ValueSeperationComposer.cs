namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IValueSeparationComposer"/>
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
