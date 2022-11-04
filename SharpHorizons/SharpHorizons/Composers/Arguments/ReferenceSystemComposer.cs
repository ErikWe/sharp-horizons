namespace SharpHorizons.Composers.Arguments;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="IReferenceSystemComposer"/>
internal sealed class ReferenceSystemComposer : IReferenceSystemComposer
{
    IReferenceSystemArgument IArgumentComposer<IReferenceSystemArgument, ReferenceSystem>.Compose(ReferenceSystem obj) => new QueryArgument(obj switch
    {
        ReferenceSystem.ICRF => "ICRF",
        ReferenceSystem.B1950 => "B1950",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(ReferenceSystem))
    });
}
