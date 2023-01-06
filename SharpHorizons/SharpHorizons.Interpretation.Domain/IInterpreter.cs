namespace SharpHorizons.Interpretation;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets <see cref="QueryResult"/> as <typeparamref name="TInterpretation"/>.</summary>
/// <typeparam name="TInterpretation">The type of the interpreted result.</typeparam>
public interface IInterpreter<TInterpretation>
{
    /// <summary>Attempts to interpret <paramref name="queryResult"/> as an instance of <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="queryResult">This <see cref="QueryResult"/> is interpreted as an instance of type <typeparamref name="TInterpretation"/>, if possible.</param>
    /// <exception cref="ArgumentException"/>
    public abstract Optional<TInterpretation> Interpret(QueryResult queryResult);
}
