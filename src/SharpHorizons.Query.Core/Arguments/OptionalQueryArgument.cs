namespace SharpHorizons.Query.Arguments;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an optional <see cref="IQueryArgument"/> of type <typeparamref name="TArgument"/>, which may or may not be provided in a <see cref="IQueryArgumentSet"/>.</summary>
/// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
public readonly record struct OptionalQueryArgument<TArgument> where TArgument : IQueryArgument
{
    /// <summary>Represents the <typeparamref name="TArgument"/> in a query, if it is provided.</summary>
    public TArgument? Argument { get; }

    /// <summary>Indicates whether the <see cref="IQueryArgument"/> is provided.</summary>
    [MemberNotNullWhen(true, nameof(Argument))]
    public bool IsProvided => Argument is not null;

    /// <summary>Represents the <typeparamref name="TArgument"/> <paramref name="argument"/> in a query.</summary>
    /// <param name="argument">The <typeparamref name="TArgument"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public OptionalQueryArgument(TArgument argument)
    {
        ArgumentNullException.ThrowIfNull(argument);

        Argument = argument;
    }
}

/// <summary>Provides functionality related to <see cref="OptionalQueryArgument{TArgument}"/>.</summary>
public static class OptionalQueryArgument
{
    /// <summary>Constructs an empty <see cref="OptionalQueryArgument{TArgument}"/>.</summary>
    /// <typeparam name="TArgument">The type of the constructed <see cref="OptionalQueryArgument{TArgument}"/>.</typeparam>
    public static OptionalQueryArgument<TArgument> Empty<TArgument>() where TArgument : IQueryArgument => new();

    /// <summary>Constructs a <see cref="OptionalQueryArgument{TArgument}"/> representing <paramref name="argument"/>.</summary>
    /// <typeparam name="TArgument">The type of the constructed <see cref="OptionalQueryArgument{TArgument}"/>.</typeparam>
    /// <param name="argument">The constructed <see cref="OptionalQueryArgument{TArgument}"/> represents this <typeparamref name="TArgument"/>.</param>
    public static OptionalQueryArgument<TArgument> Construct<TArgument>(TArgument argument) where TArgument : IQueryArgument => new(argument);
}
