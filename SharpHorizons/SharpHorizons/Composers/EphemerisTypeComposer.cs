namespace SharpHorizons.Composers;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="IEphemerisTypeComposer"/>
internal sealed class EphemerisTypeComposer : IEphemerisTypeComposer
{
    IEphemerisTypeArgument IArgumentComposer<IEphemerisTypeArgument, EphemerisType>.Compose(EphemerisType obj) => new QueryArgument(obj switch
    {
        EphemerisType.Observables => "O",
        EphemerisType.Vectors => "V",
        EphemerisType.Elements => "E",
        EphemerisType.CloseApproach => "A",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(EphemerisType))
    });
}
