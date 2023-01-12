namespace SharpHorizons.Query.Request;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Parameters;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

/// <inheritdoc cref="IQueryStringComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class QueryStringComposer : IQueryStringComposer
{
    /// <inheritdoc cref="IQueryParameterIdentifierProvider"/>
    private IQueryParameterIdentifierProvider ParameterProvider { get; }

    /// <inheritdoc cref="QueryStringComposer"/>
    /// <param name="parameterIdentifierProvider"><inheritdoc cref="ParameterProvider" path="/summary"/></param>
    public QueryStringComposer(IQueryParameterIdentifierProvider parameterIdentifierProvider)
    {
        ParameterProvider = parameterIdentifierProvider;
    }

    HorizonsQueryString IQueryStringComposer.Compose(IQueryArgumentSet queryParameters)
    {
        ArgumentNullException.ThrowIfNull(queryParameters);

        QueryBuilder builder = new();

        builder.AppendParameter(ValidateIdentifier(ParameterProvider.Command), ValidateArgument(queryParameters.Command), QueryBuilderOptions.CommonFirst);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.EphemerisType), ValidateArgument(queryParameters.EphemerisType), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.GenerateEphemeris), ValidateArgument(queryParameters.GenerateEphemeris), QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.OutputFormat), ValidateArgument(queryParameters.OutputFormat), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.ObjectDataInclusion), ValidateArgument(queryParameters.ObjectDataInclusion), QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.Origin), ValidateArgument(queryParameters.Origin), QueryBuilderOptions.Common);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.OriginCoordinate), ValidateArgument(queryParameters.OriginCoordinate), QueryBuilderOptions.Common);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.OriginCoordinateType), ValidateArgument(queryParameters.OriginCoordinateType), QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.EpochCollection), ValidateArgument(queryParameters.EpochCollection), QueryBuilderOptions.Common);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.EpochCollectionFormat), ValidateArgument(queryParameters.EpochCollectionFormat), QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.StartEpoch), ValidateArgument(queryParameters.StartEpoch), QueryBuilderOptions.Common);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.StopEpoch), ValidateArgument(queryParameters.StopEpoch), QueryBuilderOptions.Common);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.StepSize), ValidateArgument(queryParameters.StepSize), QueryBuilderOptions.Common);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.ReferencePlane), ValidateArgument(queryParameters.ReferencePlane), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.ReferenceSystem), ValidateArgument(queryParameters.ReferenceSystem), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.TimePrecision), ValidateArgument(queryParameters.TimePrecision), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.OutputUnits), ValidateArgument(queryParameters.OutputUnits), QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.VectorCorrection), ValidateArgument(queryParameters.VectorCorrection), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.TimeDeltaInclusion), ValidateArgument(queryParameters.TimeDeltaInclusion), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.VectorTableContent), ValidateArgument(queryParameters.VectorTableContent), QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.VectorLabels), ValidateArgument(queryParameters.VectorLabels), QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ValidateIdentifier(ParameterProvider.ValueSeparation), ValidateArgument(queryParameters.ValueSeparation), QueryBuilderOptions.Simple);

        return builder.Extract();
    }

    /// <summary>Validates the <see cref="IQueryParameterIdentifier"/> <paramref name="identifier"/>, throwing an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/> that is validated, <paramref name="identifier"/>.</typeparam>
    /// <param name="identifier">This <see cref="IQueryParameterIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="InvalidOperationException"/>
    private static TIdentifier ValidateIdentifier<TIdentifier>(TIdentifier identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null) where TIdentifier : IQueryParameterIdentifier
    {
        try
        {
            ArgumentNullException.ThrowIfNull(identifier, argumentExpression);
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(identifier.Identifier);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException($"The {nameof(IQueryParameterIdentifierProvider)} provided an invalid {typeof(TIdentifier).Name}.", e);
        }

        return identifier;
    }

    /// <summary>Validates the <see cref="IQueryArgument"/> <paramref name="argument"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/> that is validated, <paramref name="argument"/>.</typeparam>
    /// <param name="argument">This <see cref="IQueryArgument"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="argument"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static TArgument ValidateArgument<TArgument>(TArgument argument, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null) where TArgument : IQueryArgument
    {
        try
        {
            ArgumentNullException.ThrowIfNull(argument, argumentExpression);
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(argument.Value);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TArgument>(argumentExpression, e);
        }

        return argument;
    }

    /// <summary>Validates the <see cref="IQueryArgument"/> <paramref name="argument"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/> that is validated, <paramref name="argument"/>.</typeparam>
    /// <param name="argument">This <see cref="IQueryArgument"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="argument"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static Optional<TArgument> ValidateArgument<TArgument>(Optional<TArgument> argument, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null) where TArgument : IQueryArgument
    {
        if (argument.HasValue is false)
        {
            return argument;
        }

        ValidateArgument(argument.Value, argumentExpression);

        return argument;
    }

    /// <summary>Handles iterative construction of the <see cref="HorizonsQueryString"/> described by the composed <see cref="HorizonsQueryString"/>.</summary>
    private sealed class QueryBuilder
    {
        /// <summary>The <see cref="StringBuilder"/> responsible for iteratively constructing the <see cref="string"/> represented by the <see cref="HorizonsQueryString"/>.</summary>
        private StringBuilder StringBuilder { get; } = new();

        /// <summary>Appends a <see cref="IQueryParameterIdentifier"/> and an associated <see cref="IQueryArgument"/> to the <see cref="HorizonsQueryString"/>.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="identifier">The <see cref="IQueryParameterIdentifier"/>, identifying <paramref name="argument"/>.</param>
        /// <param name="argument">The <see cref="IQueryArgument"/>, identified by <paramref name="identifier"/>.</param>
        /// <param name="options">Provides options for how <paramref name="identifier"/> and <paramref name="argument"/> are appended to the <see cref="HorizonsQueryString"/>.</param>
        public void AppendParameter<TIdentifier, TArgument>(TIdentifier identifier, TArgument argument, QueryBuilderOptions options) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (options.PrependSeparator)
            {
                AppendSeparator();
            }

            var formattedArgument = FormatArgument(argument, options);

            StringBuilder.Append(CultureInfo.InvariantCulture, $"{identifier.Identifier}={formattedArgument}");

            if (options.AppendSeparator)
            {
                AppendSeparator();
            }
        }

        /// <summary>Appends a <see cref="IQueryParameterIdentifier"/> and an associated <see cref="IQueryArgument"/> to the <see cref="HorizonsQueryString"/> if the <see cref="IQueryArgument"/> is provided.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="identifier">The <see cref="IQueryParameterIdentifier"/>, identifying <paramref name="optionalArgument"/>.</param>
        /// <param name="optionalArgument">The optional <see cref="IQueryArgument"/>, identified by <paramref name="identifier"/>.</param>
        /// <param name="options">Provides options for how <paramref name="identifier"/> and <paramref name="optionalArgument"/> are appended to the <see cref="HorizonsQueryString"/>.</param>
        public void AppendParameterIfProvided<TIdentifier, TArgument>(TIdentifier identifier, Optional<TArgument> optionalArgument, QueryBuilderOptions options) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (optionalArgument.HasValue)
            {
                AppendParameter(identifier, optionalArgument.Value, options);
            }
        }

        /// <summary>Extracts the constructed <see cref="HorizonsQueryString"/>.</summary>
        public HorizonsQueryString Extract() => new(StringBuilder.ToString());

        /// <summary>Appends a separator to the <see cref="HorizonsQueryString"/>.</summary>
        private void AppendSeparator()
        {
            StringBuilder.Append('&');
        }

        /// <summary>Formats <paramref name="argument"/>.</summary>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="argument">The <see cref="IQueryArgument"/>.</param>
        /// <param name="options">Provides options for how <paramref name="argument"/> is formatted.</param>
        private static string FormatArgument<TArgument>(TArgument argument, QueryBuilderOptions options) where TArgument : IQueryArgument
        {
            var formattedArgument = argument.Value;

            if (options.QuotationMarks)
            {
                formattedArgument = $"'{formattedArgument}'";
            }

            if (options.URLEncoding)
            {
                formattedArgument = URLEncodeArgument(formattedArgument);
            }

            return formattedArgument;
        }

        /// <summary>URL-encodes <paramref name="argument"/>.</summary>
        /// <param name="argument">This <see cref="string"/> is URL-encoded.</param>
        private static string URLEncodeArgument(string argument) => WebUtility.UrlEncode(argument);
    }

    /// <summary>Provides options for how an <see cref="IQueryParameterIdentifier"/> and associated <see cref="IQueryArgument"/> is appended to the <see cref="HorizonsQueryString"/>.</summary>
    private readonly struct QueryBuilderOptions
    {
        /// <summary>The common <see cref="QueryBuilderOptions"/>.</summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><see cref="PrependSeparator"/> = <see langword="true"/></item>
        /// <item><see cref="AppendSeparator"/> = <see langword="false"/></item>
        /// <item><see cref="QuotationMarks"/> = <see langword="true"/></item>
        /// <item><see cref="URLEncoding"/> = <see langword="true"/></item>
        /// </list>
        /// </remarks>
        public static QueryBuilderOptions Common => new() { PrependSeparator = true, AppendSeparator = false, QuotationMarks = true, URLEncoding = true };

        /// <summary><see cref="QueryBuilderOptions"/> suitable for simple <see cref="IQueryArgument"/>.</summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><see cref="PrependSeparator"/> = <see langword="true"/></item>
        /// <item><see cref="AppendSeparator"/> = <see langword="false"/></item>
        /// <item><see cref="QuotationMarks"/> = <see langword="false"/></item>
        /// <item><see cref="URLEncoding"/> = <see langword="false"/></item>
        /// </list>
        /// </remarks>
        public static QueryBuilderOptions Simple => new() { PrependSeparator = true, AppendSeparator = false, QuotationMarks = false, URLEncoding = false };

        /// <summary>The common <see cref="QueryBuilderOptions"/> for the first parameter.</summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><see cref="PrependSeparator"/> = <see langword="false"/></item>
        /// <item><see cref="AppendSeparator"/> = <see langword="false"/></item>
        /// <item><see cref="QuotationMarks"/> = <see langword="true"/></item>
        /// <item><see cref="URLEncoding"/> = <see langword="true"/></item>
        /// </list>
        /// </remarks>
        public static QueryBuilderOptions CommonFirst => new() { PrependSeparator = false, AppendSeparator = false, QuotationMarks = true, URLEncoding = true };

        /// <summary><see cref="QueryBuilderOptions"/> suitable for simple <see cref="IQueryArgument"/> and for the first parameter.</summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><see cref="PrependSeparator"/> = <see langword="true"/></item>
        /// <item><see cref="AppendSeparator"/> = <see langword="false"/></item>
        /// <item><see cref="QuotationMarks"/> = <see langword="false"/></item>
        /// <item><see cref="URLEncoding"/> = <see langword="false"/></item>
        /// </list>
        /// </remarks>
        public static QueryBuilderOptions SimpleFirst => new() { PrependSeparator = false, AppendSeparator = false, QuotationMarks = false, URLEncoding = false };

        /// <summary>Dictates whether a separator character { &amp; } is inserted before the parameter.</summary>
        public bool PrependSeparator { get; init; }

        /// <summary>Dictates whether a separator character { &amp; } is inserted after the parameter.</summary>
        public bool AppendSeparator { get; init; }

        /// <summary>Dictates whether the <see cref="IQueryArgument"/> is added within quotation marks { ' }.</summary>
        public bool QuotationMarks { get; init; }

        /// <summary>Dictates whether the <see cref="IQueryArgument"/> is URL-encoded. This includes any potential quotation marks.</summary>
        public bool URLEncoding { get; init; }
    }
}
