namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Composing;

using System;

/// <inheritdoc cref="IVectorsQueryComposer"/>
internal sealed class VectorsQueryComposer : IVectorsQueryComposer
{
    /// <summary><inheritdoc cref="IVectorsQueryArgumentComposer" path="/summary"/></summary>
    private IVectorsQueryArgumentComposer ArgumentComposer { get; }

    /// <summary><inheritdoc cref="IQueryStringComposer" path="/summary"/></summary>
    private IQueryStringComposer QueryStringComposer { get; }

    /// <summary><inheritdoc cref="IURIComposer" path="/summary"/></summary>
    private IURIComposer URIComposer { get; }

    /// <summary><inheritdoc cref="VectorsQueryComposer" path="/summary"/></summary>
    /// <param name="argumentComposer"><inheritdoc cref="ArgumentComposer" path="/summary"/></param>
    /// <param name="queryStringComposer"><inheritdoc cref="QueryStringComposer" path="/summary"/></param>
    /// <param name="uriComposer"><inheritdoc cref="URIComposer" path="/summary"/></param>
    public VectorsQueryComposer(IVectorsQueryArgumentComposer argumentComposer, IQueryStringComposer queryStringComposer, IURIComposer uriComposer)
    {
        ArgumentComposer = argumentComposer;
        QueryStringComposer = queryStringComposer;
        URIComposer = uriComposer;
    }

    Uri IVectorsQueryComposer.Compose(IVectorsQuery query)
    {
        var argumentSet = ArgumentComposer.Compose(query);
        var queryString = QueryStringComposer.Compose(argumentSet);
        return URIComposer.Compose(queryString);
    }
}
