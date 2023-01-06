namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>Handles interpretation of an <see cref="IEphemeris{TEntry}"/> of <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="TEphemerisEntry">The <see cref="IEphemerisEntry"/> of the interpreted <see cref="IEphemeris{TEntry}"/>.</typeparam>
/// <typeparam name="THeader">The type of the <see cref="IEphemerisHeader"/>.</typeparam>
internal abstract class AEphemerisInterpreter<TEphemerisEntry, THeader> where THeader : IEphemerisHeader where TEphemerisEntry : IEphemerisEntry
{
    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <inheritdoc cref="IEphemerisEntryInterpreter{THeader, TEphemerisEntry}"/>
    private IEphemerisEntryInterpreter<THeader, TEphemerisEntry> EphemerisEntryInterpreter { get; }

    /// <inheritdoc cref="AEphemerisInterpreter{TEphemeris, THeader}"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="EphemerisEntryInterpreter" path="/summary"/></param>
    protected AEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEntryInterpreter<THeader, TEphemerisEntry> ephemerisEntryInterpreter)
    {
        EphemerisInterpretationOptionsProvider = ephemerisInterpretationOptionsProvider;

        EphemerisEntryInterpreter = ephemerisEntryInterpreter;
    }

    /// <summary>Interprets a collection of <typeparamref name="TEphemerisEntry"/> from <paramref name="queryResult"/>.</summary>
    /// <param name="header">The <typeparamref name="THeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
    /// <param name="queryResult">The <see cref="QueryResult"/>, containing the <typeparamref name="TEphemerisEntry"/>.</param>
    protected IReadOnlyList<TEphemerisEntry> InterpretEntries(THeader header, QueryResult queryResult)
    {
        var linesEnumerator = SplitLines(queryResult.Content).GetEnumerator();

        while (linesEnumerator.MoveNext())
        {
            if (linesEnumerator.Current == EphemerisInterpretationOptionsProvider.StartOfEphemeris)
            {
                break;
            }
        }

        List<TEphemerisEntry> ephemeris = new();
        StringBuilder builder = new();

        while (true)
        {
            builder.Clear();

            var shouldBreak = false;

            for (var i = 0; i < header.Quantities.RowCount; i++)
            {
                if (linesEnumerator.MoveNext() is false)
                {
                    shouldBreak = true;

                    break;
                }

                builder.AppendLine(linesEnumerator.Current);
            }

            if (shouldBreak)
            {
                break;
            }

            if (EphemerisEntryInterpreter.Interpret(header, new QueryResult(queryResult.Signature, builder.ToString())) is not { HasValue: true, Value: var ephemerisEntry })
            {
                break;
            }

            ephemeris.Add(ephemerisEntry);
        }

        return ephemeris;
    }

    /// <summary>Iterates the lines of <paramref name="input"/>.</summary>
    /// <param name="input">The lines of this <see cref="string"/> are iterated.</param>
    private static IEnumerable<string> SplitLines(string input)
    {
        using var reader = new StringReader(input);

        while (reader.ReadLine() is string line)
        {
            yield return line;
        }
    }
}
