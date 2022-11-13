namespace SharpHorizons.Query.Request;

using System.Net;

/// <summary>Handles URL-encoding of text.</summary>
internal static class URLEncoder
{
    /// <summary>URL-encodes <paramref name="text"/>.</summary>
    /// <param name="text">This <see cref="string"/> is URL-encoded.</param>
    public static string Encode(string text) => WebUtility.UrlEncode(text);
}
