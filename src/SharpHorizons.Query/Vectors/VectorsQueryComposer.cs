namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Request;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsQueryComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class VectorsQueryComposer : IVectorsQueryComposer
{
    /// <inheritdoc cref="IVectorsQueryArgumentComposer"/>
    private IVectorsQueryArgumentComposer ArgumentComposer { get; }

    /// <inheritdoc cref="IQueryStringComposer"/>
    private IQueryStringComposer QueryStringComposer { get; }

    /// <inheritdoc cref="VectorsQueryComposer"/>
    /// <param name="argumentComposer"><inheritdoc cref="ArgumentComposer" path="/summary"/></param>
    /// <param name="queryStringComposer"><inheritdoc cref="QueryStringComposer" path="/summary"/></param>
    public VectorsQueryComposer(IVectorsQueryArgumentComposer argumentComposer, IQueryStringComposer queryStringComposer)
    {
        ArgumentComposer = argumentComposer;
        QueryStringComposer = queryStringComposer;
    }

    HorizonsQueryString IVectorsQueryComposer.Compose(IVectorsQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var argumentSet = ArgumentComposer.Compose(query);

        return QueryStringComposer.Compose(argumentSet);
    }
}
