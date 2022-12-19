namespace SharpHorizons.Query.Result.HTTP;

using SharpHorizons.Interpretation;

using System.IO;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

/// <inheritdoc cref="IHTTPResultExtractor"/>
internal sealed class HTTPTextExtractor : IHTTPResultExtractor
{
    /// <summary>Configures the <see cref="JsonSerializer"/>.</summary>
    private static JsonSerializerOptions DeserializationOptions { get; } = new() { PropertyNameCaseInsensitive = true };

    /// <inheritdoc cref="IInterpretationOptionsProvider.RawTextSource"/>
    private string RawTextSourceKey { get; }

    /// <inheritdoc cref="IInterpretationOptionsProvider.RawTextVersion"/>
    private string RawTextVersionKey { get; }

    /// <inheritdoc cref="HTTPTextExtractor"/>
    /// <param name="intepretationsOptionsProvider"><inheritdoc cref="IInterpretationOptionsProvider" path="/summary"/></param>
    public HTTPTextExtractor(IInterpretationOptionsProvider intepretationsOptionsProvider)
    {
        RawTextSourceKey = FormatKey(intepretationsOptionsProvider.RawTextSource);
        RawTextVersionKey = FormatKey(intepretationsOptionsProvider.RawTextVersion);
    }

    async Task<QueryResult> IHTTPResultExtractor.ExtractAsync(HTTPQueryResult httpResult)
    {
        if (httpResult.Response.IsSuccessStatusCode is false)
        {
            throw new UnsuccesfulHTTPRequestException();
        }

        if (httpResult.Response.Content.Headers.ContentType?.MediaType is MediaTypeNames.Application.Json)
        {
            return await ExtractFromJSON(httpResult);
        }

        if (httpResult.Response.Content.Headers.ContentType?.MediaType is MediaTypeNames.Text.Plain)
        {
            return await ExtractFromRaw(httpResult);
        }

        throw new UnexpectedQueryResultFormatException();
    }

    /// <summary>Extracts a <see cref="QueryResult"/> by deserializing <paramref name="httpResult"/> as JSON.</summary>
    /// <param name="httpResult">A <see cref="QueryResult"/> is extracted from this <see cref="HTTPQueryResult"/>.</param>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    private static async Task<QueryResult> ExtractFromJSON(HTTPQueryResult httpResult)
    {
        JSON.Root? json;

        try
        {
            json = await JsonSerializer.DeserializeAsync<JSON.Root>(await httpResult.Response.Content.ReadAsStreamAsync(), DeserializationOptions);
        }
        catch (JsonException)
        {
            throw new UnexpectedQueryResultFormatException();
        }

        if (json is null)
        {
            throw new UnexpectedQueryResultFormatException();
        }

        return new(json.Signature, json.Result);
    }

    /// <summary>Extracts a <see cref="QueryResult"/> from <paramref name="httpResult"/> by parsing the raw content.</summary>
    /// <param name="httpResult">A <see cref="QueryResult"/> is extracted from this <see cref="HTTPQueryResult"/>.</param>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    private async Task<QueryResult> ExtractFromRaw(HTTPQueryResult httpResult)
    {
        using var stream = await httpResult.Response.Content.ReadAsStreamAsync();
        using StreamReader reader = new(stream);

        stream.Seek(0, SeekOrigin.Begin);

        string? source = null;
        string? version = null;

        while (await reader.ReadLineAsync() is string { Length: > 0 } line)
        {
            if (line.Split(':') is { Length: 2 } colonSplit)
            {
                var key = FormatKey(colonSplit[0]);

                if (key == RawTextSourceKey)
                {
                    source = colonSplit[1].Trim();

                    continue;
                }

                if (key == RawTextVersionKey)
                {
                    version = colonSplit[1].Trim();

                    continue;
                }
            }
        }

        if (source is null || version is null)
        {
            throw new UnexpectedQueryResultFormatException();
        }

        return new(new QueryResultSignature(source, version), await reader.ReadToEndAsync());
    }

    /// <summary>Converts <paramref name="key"/> to a format suitable for comparison.</summary>
    /// <param name="key">This <see cref="string"/> is formatted.</param>
    private static string FormatKey(string key) => key.Replace(" ", string.Empty).ToUpperInvariant();

    /// <summary>Represents the JSON format of the result.</summary>
    private static class JSON
    {
        /// <summary>The JSON root of the result.</summary>
        public class Root
        {
            /// <summary>The <see cref="JSON.Signature"/> of the result.</summary>
            public required QueryResultSignature Signature { get; init; }

            /// <summary>The content of the result.</summary>
            public required string Result { get; init; }
        }

        /// <summary>Describes the signature of the result.</summary>
        public class Signature
        {
            /// <summary>The source of the result.</summary>
            public required string Source { get; init; }

            /// <summary>The version of <see cref="Source"/> used to execute the query.</summary>
            public required string Version { get; init; }
        }
    }
}
