namespace SharpHorizons.Interpretation;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets <see cref="IQueryResult"/> as <typeparamref name="TInterpretation"/>.</summary>
/// <typeparam name="TInterpretation">The type of the interpreted result.</typeparam>
public interface IInterpreter<TInterpretation>
{
    /// <summary>Attempts to interpret <paramref name="queryResult"/>, resulting in an instance of type <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="queryResult">This <see cref="IQueryResult"/> is interpreted as an instance of type <typeparamref name="TInterpretation"/>, if possible.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract Optional<TInterpretation> Interpret(IQueryResult queryResult);
}
