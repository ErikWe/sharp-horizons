namespace SharpHorizons.Composers;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="IReferencePlaneComposer"/>
internal sealed class ReferencePlaneComposer : IReferencePlaneComposer
{
    IReferencePlaneArgument IArgumentComposer<IReferencePlaneArgument, ReferencePlane>.Compose(ReferencePlane obj) => new QueryArgument(obj switch
    {
        ReferencePlane.Ecliptic => "E",
        ReferencePlane.Frame => "F",
        ReferencePlane.BodyEquator => "B",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(ReferencePlane))
    });
}
