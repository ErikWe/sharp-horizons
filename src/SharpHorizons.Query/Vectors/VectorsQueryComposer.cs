namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Request;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsQueryComposer"/>
internal sealed class VectorsQueryComposer : IVectorsQueryComposer
{
    /// <inheritdoc cref="IVectorsQueryArgumentComposer"/>
    public required IVectorsQueryArgumentComposer ArgumentComposer { private get; init; }

    /// <inheritdoc cref="IQueryStringComposer"/>
    public required IQueryStringComposer QueryStringComposer { private get; init; }

    /// <inheritdoc cref="VectorsQueryComposer"/>
    public VectorsQueryComposer() { }

    /// <inheritdoc cref="VectorsQueryComposer"/>
    /// <param name="argumentComposer"><inheritdoc cref="ArgumentComposer" path="/summary"/></param>
    /// <param name="queryStringComposer"><inheritdoc cref="QueryStringComposer" path="/summary"/></param>
    [SetsRequiredMembers]
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
