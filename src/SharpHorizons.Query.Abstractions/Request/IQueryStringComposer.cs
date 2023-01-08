namespace SharpHorizons.Query.Request;

using SharpHorizons.Query.Arguments;

using System;

/// <summary>Composes <see cref="HorizonsQueryString"/> describing <see cref="IQueryArgumentSet"/>.</summary>
public interface IQueryStringComposer
{
    /// <summary>Composes a <see cref="HorizonsQueryString"/> describing <paramref name="queryArguments"/>.</summary>
    /// <param name="queryArguments">The composed <see cref="HorizonsQueryString"/> describes this <see cref="IQueryArgumentSet"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract HorizonsQueryString Compose(IQueryArgumentSet queryArguments);
}
