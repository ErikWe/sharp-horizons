namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Composing;
using SharpHorizons.Query.Parameters;

using System;

/// <inheritdoc cref="IVectorsQueryComposer"/>
internal sealed class VectorsQueryComposer : IVectorsQueryComposer
{
    /// <summary><inheritdoc cref="IVectorsQueryArgumentComposer" path="/summary"/></summary>
    private IVectorsQueryArgumentComposer ArgumentComposer { get; }

    /// <summary><inheritdoc cref="IQueryParameterMapper" path="/summary"/></summary>
    private IQueryParameterMapper ParameterMapper { get; }

    /// <summary><inheritdoc cref="IQueryStringComposer" path="/summary"/></summary>
    private IQueryStringComposer QueryStringComposer { get; }

    /// <summary><inheritdoc cref="IURIComposer" path="/summary"/></summary>
    private IURIComposer URIComposer { get; }

    /// <summary><inheritdoc cref="VectorsQueryComposer" path="/summary"/></summary>
    /// <param name="argumentComposer"><inheritdoc cref="ArgumentComposer" path="/summary"/></param>
    /// <param name="parameterMapper"><inheritdoc cref="ParameterMapper" path="/summary"/></param>
    /// <param name="queryStringComposer"><inheritdoc cref="QueryStringComposer" path="/summary"/></param>
    /// <param name="uriComposer"><inheritdoc cref="URIComposer" path="/summary"/></param>
    public VectorsQueryComposer(IVectorsQueryArgumentComposer argumentComposer, IQueryParameterMapper parameterMapper, IQueryStringComposer queryStringComposer, IURIComposer uriComposer)
    {
        ArgumentComposer = argumentComposer;
        ParameterMapper = parameterMapper;
        QueryStringComposer = queryStringComposer;
        URIComposer = uriComposer;
    }

    Uri IVectorsQueryComposer.Compose(IVectorsQuery query)
    {
        var argumentSet = ArgumentComposer.Compose(query);
        var parameterSet = ParameterMapper.Map(argumentSet);
        var queryString = QueryStringComposer.Compose(parameterSet);
        return URIComposer.Compose(queryString);
    }
}
