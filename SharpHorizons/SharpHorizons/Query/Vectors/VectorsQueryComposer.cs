namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Request;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsQueryComposer"/>
internal sealed class VectorsQueryComposer : IVectorsQueryComposer
{
    /// <summary><inheritdoc cref="IVectorsQueryArgumentComposer" path="/summary"/></summary>
    public required IVectorsQueryArgumentComposer ArgumentComposer { private get; init; }

    /// <summary><inheritdoc cref="IQueryStringComposer" path="/summary"/></summary>
    public required IQueryStringComposer QueryStringComposer { private get; init; }

    /// <summary><inheritdoc cref="IURIComposer" path="/summary"/></summary>
    public required IURIComposer URIComposer { private get; init; }


    /// <inheritdoc cref="VectorsQueryComposer"/>
    public VectorsQueryComposer() { }

    /// <inheritdoc cref="VectorsQueryComposer"/>
    /// <param name="argumentComposer"><inheritdoc cref="ArgumentComposer" path="/summary"/></param>
    /// <param name="queryStringComposer"><inheritdoc cref="QueryStringComposer" path="/summary"/></param>
    /// <param name="uriComposer"><inheritdoc cref="URIComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public VectorsQueryComposer(IVectorsQueryArgumentComposer argumentComposer, IQueryStringComposer queryStringComposer, IURIComposer uriComposer)
    {
        ArgumentComposer = argumentComposer;
        QueryStringComposer = queryStringComposer;
        URIComposer = uriComposer;
    }

    HorizonsQueryURI IVectorsQueryComposer.Compose(IVectorsQuery query)
    {
        var argumentSet = ArgumentComposer.Compose(query);
        var queryString = QueryStringComposer.Compose(argumentSet);
        return URIComposer.Compose(queryString);
    }
}
