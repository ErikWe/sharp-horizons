namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an optional <see cref="IQueryParameter{TIdentifier, TArgument}"/> of type <typeparamref name="TParameter"/>, which may or may not be provided in a <see cref="IQueryParameterSet"/>.</summary>
/// <typeparam name="TParameter">The type of the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</typeparam>
/// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
/// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
public readonly record struct OptionalQueryParameter<TParameter, TIdentifier, TArgument> where TParameter : IQueryParameter<TIdentifier, TArgument> where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
{
    /// <summary>Represents the <typeparamref name="TParameter"/> in a query, if it is provided.</summary>
    public TParameter? Parameter { get; }

    /// <summary>Indicates whether the <see cref="IQueryParameter{TIdentifier, TArgument}"/> is provided.</summary>
    [MemberNotNullWhen(true, nameof(Parameter))]
    public bool IsProvided => Parameter is not null;

    /// <summary>Represents the <typeparamref name="TParameter"/> <paramref name="argument"/> in a query.</summary>
    /// <param name="argument">The <typeparamref name="TParameter"/> in a query.</param>
    public OptionalQueryParameter(TParameter argument)
    {
        ArgumentNullException.ThrowIfNull(argument);

        Parameter = argument;
    }

    /// <summary>Represents the <typeparamref name="TParameter"/> <paramref name="argument"/> in a query.</summary>
    /// <param name="argument">The <typeparamref name="TParameter"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public static implicit operator OptionalQueryParameter<TParameter, TIdentifier, TArgument>(TParameter argument) => new(argument);
}

/// <summary>Provides functionality related to <see cref="OptionalQueryParameter{TParameter, TIdentifier, TArgument}"/>.</summary>
public static class OptionalQueryParameter
{
    /// <summary>Constructs an empty <see cref="OptionalQueryParameter{TParameter, TIdentifier, TArgument}"/>.</summary>
    /// <typeparam name="TParameter">The type of the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</typeparam>
    /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
    /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
    public static OptionalQueryParameter<TParameter, TIdentifier, TArgument> Empty<TParameter, TIdentifier, TArgument>() where TParameter : IQueryParameter<TIdentifier, TArgument> where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument => new();

    /// <summary>Constructs a <see cref="OptionalQueryParameter{TParameter, TIdentifier, TArgument}"/> representing <paramref name="parameter"/>.</summary>
    /// <typeparam name="TParameter">The type of the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</typeparam>
    /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
    /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
    /// <param name="parameter">The constructed <see cref="OptionalQueryParameter{TParameter, TIdentifier, TArgument}"/> represents this <typeparamref name="TParameter"/>.</param>
    public static OptionalQueryParameter<TParameter, TIdentifier, TArgument> Construct<TParameter, TIdentifier, TArgument>(TParameter parameter) where TParameter : IQueryParameter<TIdentifier, TArgument> where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument => new(parameter);
}
