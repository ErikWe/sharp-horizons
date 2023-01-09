namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITimeDeltaInclusionComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class TimeDeltaInclusionComposer : ITimeDeltaInclusionComposer
{
    ITimeDeltaInclusionArgument IArgumentComposer<ITimeDeltaInclusionArgument, TimeDeltaInclusion>.Compose(TimeDeltaInclusion obj) => new QueryArgument(obj switch
    {
        TimeDeltaInclusion.Disable => "NO",
        TimeDeltaInclusion.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
