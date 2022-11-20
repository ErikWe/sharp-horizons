namespace SharpHorizons.Interpretation;

using System.Collections.Generic;
using System.IO;

/// <summary>Extension methods for <see cref="string"/>.</summary>
internal static class StringExtensions
{
    /// <summary>Iterates the lines of <paramref name="input"/>.</summary>
    /// <param name="input">The lines of this <see cref="string"/> are iterated.</param>
    public static IEnumerable<string> SplitLines(this string input)
    {
        using var reader = new StringReader(input);

        while (reader.ReadLine() is string line)
        {
            yield return line;
        }
    }
}
