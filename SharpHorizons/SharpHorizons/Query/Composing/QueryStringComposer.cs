namespace SharpHorizons.Query.Composing;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Parameters;

using System.Text;

/// <inheritdoc cref="IQueryStringComposer"/>
internal sealed class QueryStringComposer : IQueryStringComposer
{
    HorizonsQueryString IQueryStringComposer.Compose(IQueryParameterSet queryParameters)
    {
        QueryBuilder builder = new();

        builder.AppendParameter(queryParameters.Command, initialSeparator: false);

        builder.AppendParameterIfProvided(queryParameters.EphemerisType);
        builder.AppendParameterIfProvided(queryParameters.GenerateEphemerides);

        builder.AppendParameterIfProvided(queryParameters.OutputFormat);
        builder.AppendParameterIfProvided(queryParameters.ObjectDataInclusion);

        builder.AppendParameterIfProvided(queryParameters.Origin);
        builder.AppendParameterIfProvided(queryParameters.OriginCoordinate);
        builder.AppendParameterIfProvided(queryParameters.OriginCoordinateType);

        builder.AppendParameterIfProvided(queryParameters.EpochCollection);
        builder.AppendParameterIfProvided(queryParameters.EpochCollectionFormat);

        builder.AppendParameterIfProvided(queryParameters.StartEpoch);
        builder.AppendParameterIfProvided(queryParameters.StopEpoch);
        builder.AppendParameterIfProvided(queryParameters.StepSize);

        builder.AppendParameterIfProvided(queryParameters.ReferencePlane);
        builder.AppendParameterIfProvided(queryParameters.ReferenceSystem);
        builder.AppendParameterIfProvided(queryParameters.TimePrecision);
        builder.AppendParameterIfProvided(queryParameters.OutputUnits);

        builder.AppendParameterIfProvided(queryParameters.VectorCorrection);
        builder.AppendParameterIfProvided(queryParameters.TimeDeltaInclusion);
        builder.AppendParameterIfProvided(queryParameters.VectorTableContent);

        builder.AppendParameterIfProvided(queryParameters.ElementLabels);
        builder.AppendParameterIfProvided(queryParameters.VectorLabels);
        builder.AppendParameterIfProvided(queryParameters.ValueSeparation);

        return builder.Extract();
    }

    /// <summary>Handles iterative construction of the <see cref="string"/> described by the composed <see cref="HorizonsQueryString"/>.</summary>
    private sealed class QueryBuilder
    {
        /// <summary>The <see cref="StringBuilder"/> responsible for iteratively construction the <see cref="string"/>.</summary>
        private StringBuilder StringBuilder { get; } = new();

        /// <summary>Appends a <see cref="IQueryParameter{TIdentifier, TArgument}"/> to the <see cref="string"/>.</summary>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="parameter">The <see cref="IQueryParameter{TIdentifier, TArgument}"/> of the argument.</param>
        /// <param name="initialSeparator">Dictates whether a separator is inserted before the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</param>
        /// <param name="finalSeparator">Dictates whether a separator is inserted after the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</param>
        public void AppendParameter<TIdentifier, TArgument>(IQueryParameter<TIdentifier, TArgument> parameter, bool initialSeparator = true, bool finalSeparator = false) where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (initialSeparator)
            {
                AppendSeparator();
            }

            StringBuilder.Append($"{parameter.ParameterIdentifier.Identifier}='{parameter.Argument.Value}'");

            if (finalSeparator)
            {
                AppendSeparator();
            }
        }

        /// <summary>Appends a <see cref="IQueryParameter{TIdentifier, TArgument}"/> to the <see cref="string"/> if it is provided.</summary>
        /// <typeparam name="TParameter">The type of the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</typeparam>
        /// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
        /// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
        /// <param name="optionalParameter">The optional <see cref="IQueryParameterIdentifier"/> of the argument.</param>
        /// <param name="initialSeparator">Dictates whether a separator is inserted before the <see cref="IQueryParameter{TIdentifier, TArgument}"/>. No separator is inserted if the <see cref="IQueryArgument"/> is not provided.</param>
        /// <param name="finalSeparator">Dictates whether a separator is inserted after the <see cref="IQueryParameter{TIdentifier, TArgument}"/>. No separator is inserted if the <see cref="IQueryArgument"/> is not provided.</param>
        public void AppendParameterIfProvided<TParameter, TIdentifier, TArgument>(OptionalQueryParameter<TParameter, TIdentifier, TArgument> optionalParameter, bool initialSeparator = true, bool finalSeparator = false) where TParameter : IQueryParameter<TIdentifier, TArgument> where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
        {
            if (optionalParameter.IsProvided)
            {
                AppendParameter(optionalParameter.Parameter, initialSeparator, finalSeparator);
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
