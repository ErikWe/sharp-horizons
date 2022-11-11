namespace SharpHorizons.Query.Composing;

using SharpHorizons.Query;

using System;

/// <inheritdoc cref="IURIComposer"/>
internal sealed class URIComposer : IURIComposer
{
    /// <summary>The URI of the Horizons API.</summary>
    private Uri HorizonsAPIAddress { get; } = new("""https://ssd.jpl.nasa.gov/api/horizons.api?""");

    Uri IURIComposer.Compose(HorizonsQueryString query) => new(HorizonsAPIAddress, $"?{query}");
}
