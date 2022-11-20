namespace SharpHorizons.Query.Result.HTTP;

using SharpHorizons.Interpretation;

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Mime;

/// <inheritdoc cref="IHTTPResultExtractor"/>
internal sealed class HTTPTextExtractor : IHTTPResultExtractor
{
    /// <summary>Configures the <see cref="JsonSerializer"/>.</summary>
    private static JsonSerializerOptions DeserializationOptions { get; } = new() { PropertyNameCaseInsensitive = true };

    /// <summary><inheritdoc cref="IInterpretationOptionsProvider.RawTextSource"/></summary>
    private string RawTextSourceKey { get; }

    /// <summary><inheritdoc cref="IInterpretationOptionsProvider.RawTextVersion"/></summary>
    private string RawTextVersionKey { get; }

    /// <inheritdoc cref="HTTPTextExtractor"/>
    /// <param name="intepretationsOptionsProvider"><inheritdoc cref="IInterpretationOptionsProvider" path="/summary"/></param>
    public HTTPTextExtractor(IInterpretationOptionsProvider intepretationsOptionsProvider)
    {
        RawTextSourceKey = FormatKey(intepretationsOptionsProvider.RawTextSource);
        RawTextVersionKey = FormatKey(intepretationsOptionsProvider.RawTextVersion);
    }

    async Task<IQueryResult> IHTTPResultExtractor.ExtractAsync(IHTTPQueryResult httpResult)
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

    /// <summary>Extracts a <see cref="IQueryResult"/> by deserializing <paramref name="httpResult"/> as JSON.</summary>
    /// <param name="httpResult">A <see cref="IQueryResult"/> is extracted from this <see cref="IHTTPQueryResult"/>.</param>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    private static async Task<IQueryResult> ExtractFromJSON(IHTTPQueryResult httpResult)
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

        return new QueryResult(json.Signature, json.Result);
    }

    /// <summary>Extracts a <see cref="IQueryResult"/> from <paramref name="httpResult"/> by parsing the raw content.</summary>
    /// <param name="httpResult">A <see cref="IQueryResult"/> is extracted from this <see cref="IHTTPQueryResult"/>.</param>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    private async Task<IQueryResult> ExtractFromRaw(IHTTPQueryResult httpResult)
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

        return new QueryResult(new QueryResultSignature(source, version), await reader.ReadToEndAsync());
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
