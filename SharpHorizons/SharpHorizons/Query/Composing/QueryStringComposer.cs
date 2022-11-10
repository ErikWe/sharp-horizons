namespace SharpHorizons.Query.Composing;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IQueryStringComposer"/>
internal sealed class QueryStringComposer : IQueryStringComposer
{
    /// <summary><inheritdoc cref="IQueryParameterProvider" path="/summary"/></summary>
    private IQueryParameterProvider ParameterProvider { get; }

    /// <summary><inheritdoc cref="QueryStringComposer" path="/summary"/></summary>
    /// <param name="parameterProvider"><inheritdoc cref="ParameterProvider" path="/summary"/></param>
    public QueryStringComposer(IQueryParameterProvider parameterProvider)
    {
        ParameterProvider = parameterProvider;
    }

    HorizonsQueryString IQueryStringComposer.Compose(IQueryArgumentSet queryArguments)
    {
        
    }
}
