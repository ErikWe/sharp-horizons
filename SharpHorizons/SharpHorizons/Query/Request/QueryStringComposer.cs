namespace SharpHorizons.Query.Request;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Parameters;

using System.Text;

/// <inheritdoc cref="IQueryStringComposer"/>
internal sealed class QueryStringComposer : IQueryStringComposer
{
    /// <summary><inheritdoc cref="IQueryParameterIdentifierProvider" path="/summary"/></summary>
    private IQueryParameterIdentifierProvider ParameterProvider { get; }

    /// <inheritdoc cref="QueryStringComposer"/>
    /// <param name="parameterIdentifierProvider"><inheritdoc cref="ParameterProvider" path="/summary"/></param>
    public QueryStringComposer(IQueryParameterIdentifierProvider parameterIdentifierProvider)
    {
        ParameterProvider = parameterIdentifierProvider;
    }

    HorizonsQueryString IQueryStringComposer.Compose(IQueryArgumentSet queryParameters)
    {
        QueryBuilder builder = new();

        builder.AppendParameter(ParameterProvider.Command, queryParameters.Command, QueryBuilderOptions.Common with { PrependSeparator = false });

        builder.AppendParameterIfProvided(ParameterProvider.EphemerisType, queryParameters.EphemerisType, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.GenerateEphemerides, queryParameters.GenerateEphemerides, QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ParameterProvider.OutputFormat, queryParameters.OutputFormat, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.ObjectDataInclusion, queryParameters.ObjectDataInclusion, QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ParameterProvider.Origin, queryParameters.Origin);
        builder.AppendParameterIfProvided(ParameterProvider.OriginCoordinate, queryParameters.OriginCoordinate);
        builder.AppendParameterIfProvided(ParameterProvider.OriginCoordinateType, queryParameters.OriginCoordinateType, QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ParameterProvider.EpochCollection, queryParameters.EpochCollection);
        builder.AppendParameterIfProvided(ParameterProvider.EpochCollectionFormat, queryParameters.EpochCollectionFormat, QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ParameterProvider.StartEpoch, queryParameters.StartEpoch);
        builder.AppendParameterIfProvided(ParameterProvider.StopEpoch, queryParameters.StopEpoch);
        builder.AppendParameterIfProvided(ParameterProvider.StepSize, queryParameters.StepSize);

        builder.AppendParameterIfProvided(ParameterProvider.ReferencePlane, queryParameters.ReferencePlane, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.ReferenceSystem, queryParameters.ReferenceSystem, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.TimePrecision, queryParameters.TimePrecision, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.OutputUnits, queryParameters.OutputUnits, QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ParameterProvider.VectorCorrection, queryParameters.VectorCorrection, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.TimeDeltaInclusion, queryParameters.TimeDeltaInclusion, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.VectorTableContent, queryParameters.VectorTableContent, QueryBuilderOptions.Simple);

        builder.AppendParameterIfProvided(ParameterProvider.ElementLabels, queryParameters.ElementLabels, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.VectorLabels, queryParameters.VectorLabels, QueryBuilderOptions.Simple);
        builder.AppendParameterIfProvided(ParameterProvider.ValueSeparation, queryParameters.ValueSeparation, QueryBuilderOptions.Simple);

        return builder.Extract();
    }

    /// <summary>Handles iterative construction of the <see cref="string"/> described by the composed <see cref="HorizonsQueryString"/>.</summary>
    private sealed class QueryBuilder
    {
        /// <summary>The <see cref="StringBuilder"/> responsible for iteratively construction the <see cref="string"/>.</summary>
        private StringBuilder StringBuilder { get; } = new();

        /// <summary>Appends a <see cref="IQueryParameterIdentifier"/> and an associated <see cref="IQueryArgument"/> to the <see cref="string"/>.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="identifier">The <see cref="IQueryParameterIdentifier"/>, identifying <paramref name="argument"/>.</param>
        /// <param name="argument">The <see cref="IQueryArgument"/>, identified by <paramref name="identifier"/>.</param>
        /// <param name="options">Provides options for how <paramref name="identifier"/> and <paramref name="argument"/> are appended to the <see cref="string"/>.</param>
        public void AppendParameter<TIdentifier, TArgument>(TIdentifier identifier, TArgument argument, QueryBuilderOptions options) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (options.PrependSeparator)
            {
                AppendSeparator();
            }

            var formattedArgument = FormatArgument(argument, options);

            StringBuilder.Append($"{identifier.Identifier}={formattedArgument}");

            if (options.AppendSeparator)
            {
                AppendSeparator();
            }
        }

        /// <summary>Appends a <see cref="IQueryParameterIdentifier"/> and an associated <see cref="IQueryArgument"/> to the <see cref="string"/>.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="identifier">The <see cref="IQueryParameterIdentifier"/>, identifying <paramref name="argument"/>.</param>
        /// <param name="argument">The <see cref="IQueryArgument"/>, identified by <paramref name="identifier"/>.</param>
        public void AppendParameter<TIdentifier, TArgument>(TIdentifier identifier, TArgument argument) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument => AppendParameter(identifier, argument, QueryBuilderOptions.Common);

        /// <summary>Appends a <see cref="IQueryParameterIdentifier"/> and an associated <see cref="IQueryArgument"/> to the <see cref="string"/> if the <see cref="IQueryArgument"/> is provided.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="identifier">The <see cref="IQueryParameterIdentifier"/>, identifying <paramref name="optionalArgument"/>.</param>
        /// <param name="optionalArgument">The optional <see cref="IQueryArgument"/>, identified by <paramref name="identifier"/>.</param>
        /// <param name="options">Provides options for how <paramref name="identifier"/> and <paramref name="optionalArgument"/> are appended to the <see cref="string"/>.</param>
        public void AppendParameterIfProvided<TIdentifier, TArgument>(TIdentifier identifier, OptionalQueryArgument<TArgument> optionalArgument, QueryBuilderOptions options) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (optionalArgument.IsProvided)
            {
                AppendParameter(identifier, optionalArgument.Argument, options);
            }
        }

        /// <summary>Appends a <see cref="IQueryParameterIdentifier"/> and an associated <see cref="IQueryArgument"/> to the <see cref="string"/> if the <see cref="IQueryArgument"/> is provided.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="identifier">The <see cref="IQueryParameterIdentifier"/>, identifying <paramref name="optionalArgument"/>.</param>
        /// <param name="optionalArgument">The optional <see cref="IQueryArgument"/>, identified by <paramref name="identifier"/>.</param>
        public void AppendParameterIfProvided<TIdentifier, TArgument>(TIdentifier identifier, OptionalQueryArgument<TArgument> optionalArgument) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument => AppendParameterIfProvided(identifier, optionalArgument, QueryBuilderOptions.Common);

        /// <summary>Extracts the constructed <see cref="string"/>.</summary>
        public string Extract() => StringBuilder.ToString();

        /// <summary>Appends a separator to the <see cref="string"/>.</summary>
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
                formattedArgument = URLEncoder.Encode(formattedArgument);
            }

            return formattedArgument;
        }
    }

    /// <summary>Provides options for how an <see cref="IQueryParameterIdentifier"/> and associated <see cref="IQueryArgument"/> is appended to the <see cref="string"/>.</summary>
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
