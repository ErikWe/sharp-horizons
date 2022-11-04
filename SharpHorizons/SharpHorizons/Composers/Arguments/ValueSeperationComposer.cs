namespace SharpHorizons.Composers.Arguments;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="IValueSeparationComposer"/>
internal sealed class ValueSeperationComposer : IValueSeparationComposer
{
    IValueSeparationArgument IArgumentComposer<IValueSeparationArgument, ValueSeparation>.Compose(ValueSeparation obj) => new QueryArgument(obj switch
    {
        ValueSeparation.CommaSeparation => "YES",
        ValueSeparation.WhitespaceSeparation => "NO",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(ValueSeparation))
    });
}
