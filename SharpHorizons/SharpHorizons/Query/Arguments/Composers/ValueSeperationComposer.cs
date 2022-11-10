namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;
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
