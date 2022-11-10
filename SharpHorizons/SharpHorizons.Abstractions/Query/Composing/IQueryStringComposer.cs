namespace SharpHorizons.Query.Composing;

using SharpHorizons.Query.Parameters;

/// <summary>Composes <see cref="HorizonsQueryString"/> describing <see cref="IQueryParameterSet"/>.</summary>
public interface IQueryStringComposer
{
    /// <summary>Composes a <see cref="HorizonsQueryString"/> describing <paramref name="queryParameters"/>.</summary>
    /// <param name="queryParameters">The composed <see cref="HorizonsQueryString"/> describes this <see cref="IQueryParameterSet"/>.</param>
    public abstract HorizonsQueryString Compose(IQueryParameterSet queryParameters);
}
