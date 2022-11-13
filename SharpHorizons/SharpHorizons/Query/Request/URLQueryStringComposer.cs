namespace SharpHorizons.Query.Request;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Parameters;

using System.Text;

/// <inheritdoc cref="IQueryStringComposer"/>
internal sealed class URLQueryStringComposer : IQueryStringComposer
{
    /// <summary><inheritdoc cref="IQueryParameterProvider" path="/summary"/></summary>
    private IQueryParameterProvider ParameterProvider { get; }

    /// <summary><inheritdoc cref="URLQueryStringComposer" path="/summary"/></summary>
    /// <param name="parameterProvider"><inheritdoc cref="ParameterProvider" path="/summary"/></param>
    public URLQueryStringComposer(IQueryParameterProvider parameterProvider)
    {
        ParameterProvider = parameterProvider;
    }

    HorizonsQueryString IQueryStringComposer.Compose(IQueryArgumentSet queryParameters)
    {
        QueryBuilder builder = new();

        builder.AppendParameter(ParameterProvider.Command, queryParameters.Command, initialSeparator: false);

        builder.AppendParameterIfProvided(ParameterProvider.EphemerisType, queryParameters.EphemerisType);
        builder.AppendParameterIfProvided(ParameterProvider.GenerateEphemerides, queryParameters.GenerateEphemerides);

        builder.AppendParameterIfProvided(ParameterProvider.OutputFormat, queryParameters.OutputFormat);
        builder.AppendParameterIfProvided(ParameterProvider.ObjectDataInclusion, queryParameters.ObjectDataInclusion);

        builder.AppendParameterIfProvided(ParameterProvider.Origin, queryParameters.Origin);
        builder.AppendParameterIfProvided(ParameterProvider.OriginCoordinate, queryParameters.OriginCoordinate);
        builder.AppendParameterIfProvided(ParameterProvider.OriginCoordinateType, queryParameters.OriginCoordinateType);

        builder.AppendParameterIfProvided(ParameterProvider.EpochCollection, queryParameters.EpochCollection);
        builder.AppendParameterIfProvided(ParameterProvider.EpochCollectionFormat, queryParameters.EpochCollectionFormat);

        builder.AppendParameterIfProvided(ParameterProvider.StartEpoch, queryParameters.StartEpoch);
        builder.AppendParameterIfProvided(ParameterProvider.StopEpoch, queryParameters.StopEpoch);
        builder.AppendParameterIfProvided(ParameterProvider.StepSize, queryParameters.StepSize);

        builder.AppendParameterIfProvided(ParameterProvider.ReferencePlane, queryParameters.ReferencePlane);
        builder.AppendParameterIfProvided(ParameterProvider.ReferenceSystem, queryParameters.ReferenceSystem);
        builder.AppendParameterIfProvided(ParameterProvider.TimePrecision, queryParameters.TimePrecision);
        builder.AppendParameterIfProvided(ParameterProvider.OutputUnits, queryParameters.OutputUnits);

        builder.AppendParameterIfProvided(ParameterProvider.VectorCorrection, queryParameters.VectorCorrection);
        builder.AppendParameterIfProvided(ParameterProvider.TimeDeltaInclusion, queryParameters.TimeDeltaInclusion);
        builder.AppendParameterIfProvided(ParameterProvider.VectorTableContent, queryParameters.VectorTableContent);

        builder.AppendParameterIfProvided(ParameterProvider.ElementLabels, queryParameters.ElementLabels);
        builder.AppendParameterIfProvided(ParameterProvider.VectorLabels, queryParameters.VectorLabels);
        builder.AppendParameterIfProvided(ParameterProvider.ValueSeparation, queryParameters.ValueSeparation);

        return URLEncoder.Encode(builder.Extract());
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
        /// <param name="initialSeparator">Dictates whether a separator is inserted before the parameter.</param>
        /// <param name="finalSeparator">Dictates whether a separator is inserted after the parameter>.</param>
        public void AppendParameter<TIdentifier, TArgument>(TIdentifier identifier, TArgument argument, bool initialSeparator = true, bool finalSeparator = false) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (initialSeparator)
            {
                AppendSeparator();
            }

            StringBuilder.Append($"{identifier.Identifier}='{argument.Value}'");

            if (finalSeparator)
            {
                AppendSeparator();
            }
        }

        /// <summary>Appends a <see cref="IQueryParameterIdentifier"/> and an associated <see cref="IQueryArgument"/> to the <see cref="string"/> if the <see cref="IQueryArgument"/> is provided.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="identifier">The <see cref="IQueryParameterIdentifier"/>, identifying <paramref name="optionalArgument"/>.</param>
        /// <param name="optionalArgument">The optional <see cref="IQueryArgument"/>, identified by <paramref name="identifier"/>.</param>
        /// <param name="initialSeparator">Dictates whether a separator is inserted before the parameter. No separator is inserted if the <see cref="IQueryArgument"/> is not provided.</param>
        /// <param name="finalSeparator">Dictates whether a separator is inserted after the parameter. No separator is inserted if the <see cref="IQueryArgument"/> is not provided.</param>
        public void AppendParameterIfProvided<TIdentifier, TArgument>(TIdentifier identifier, OptionalQueryArgument<TArgument> optionalArgument, bool initialSeparator = true, bool finalSeparator = false) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (optionalArgument.IsProvided)
            {
                AppendParameter(identifier, optionalArgument.Argument, initialSeparator, finalSeparator);
            }
        }

        /// <summary>Appends a separator to the <see cref="string"/>.</summary>
        public void AppendSeparator()
        {
            StringBuilder.Append('&');
        }

        /// <summary>Extracts the constructed <see cref="string"/>.</summary>
        public string Extract() => StringBuilder.ToString();
    }
}
