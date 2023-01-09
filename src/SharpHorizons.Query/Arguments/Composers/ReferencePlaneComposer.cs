namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IReferencePlaneComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ReferencePlaneComposer : IReferencePlaneComposer
{
    IReferencePlaneArgument IArgumentComposer<IReferencePlaneArgument, ReferencePlane>.Compose(ReferencePlane obj) => new QueryArgument(obj switch
    {
        ReferencePlane.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        ReferencePlane.Ecliptic => "E",
        ReferencePlane.Frame => "F",
        ReferencePlane.BodyEquator => "B",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
