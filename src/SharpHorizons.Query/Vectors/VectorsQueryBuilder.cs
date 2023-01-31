namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IVectorsQueryBuilder"/>
internal sealed class VectorsQueryBuilder : IVectorsQueryBuilder
{
    /// <inheritdoc cref="IVectorsQueryValidator"/>
    private IVectorsQueryValidator Validator { get; }

    /// <summary>Indicates whether the most recently executed command was <see cref="IVectorsQueryBuilder.Build"/>.</summary>
    private bool BuildWasPreviousCommand { get; set; }

    /// <inheritdoc cref="MutableVectorsQuery"/>
    private MutableVectorsQuery VectorsQuery { get; set; }

    /// <inheritdoc cref="VectorsQueryBuilder"/>
    /// <param name="validator"><inheritdoc cref="Validator" path="/summary"/></param>
    /// <param name="target"><inheritdoc cref="IVectorsQuery.Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="IVectorsQuery.Origin" path="/summary"/></param>
    /// <param name="epochSelection"><inheritdoc cref="IVectorsQuery.EpochSelection" path="/summary"/></param>
    public VectorsQueryBuilder(IVectorsQueryValidator validator, ITarget target, IOrigin origin, IEpochSelection epochSelection)
    {
        Validator = validator;

        VectorsQuery = new(target, origin, epochSelection);
    }

    /// <summary>Constructs a <see cref="VectorsQueryBuilder"/>, handling incremental construction of <see cref="IVectorsQuery"/> - with an initial configuration <paramref name="vectorsQuery"/>.</summary>
    /// <param name="validator"><inheritdoc cref="Validator" path="/summary"/></param>
    /// <param name="vectorsQuery">The initial configuration of the <see cref="VectorsQueryBuilder"/>. This instance is not modified.</param>
    public VectorsQueryBuilder(IVectorsQueryValidator validator, IVectorsQuery vectorsQuery)
    {
        Validator = validator;

        VectorsQuery = new(vectorsQuery);
    }

    /// <summary>Constructs a new <see cref="MutableVectorsQuery"/>, <see cref="VectorsQuery"/>, if necessary.</summary>
    private void ConstructNewInstanceIfNecessary()
    {
        if (BuildWasPreviousCommand is false)
        {
            return;
        }

        BuildWasPreviousCommand = false;

        VectorsQuery = new MutableVectorsQuery(VectorsQuery);
    }

    /// <summary>Specifies some property of <see cref="VectorsQuery"/>, with validation through <paramref name="validator"/>, and handling construction of new instances of <see cref="MutableVectorsQuery"/> when necessary.</summary>
    /// <typeparam name="T">The type of the property of <see cref="VectorsQuery"/> that is specified.</typeparam>
    /// <param name="argument">The value of the property of <see cref="VectorsQuery"/>.</param>
    /// <param name="setter">Sets some property of <see cref="VectorsQuery"/>.</param>
    /// <param name="validator">Handles validation of <paramref name="argument"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="argument"/>.</param>
    private IVectorsQueryBuilder Specify<T>(T argument, Action<MutableVectorsQuery> setter, Action<T, string?> validator, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null)
    {
        validator(argument, argumentExpression);

        ConstructNewInstanceIfNecessary();

        setter(VectorsQuery);

        return this;
    }

    /// <inheritdoc/>
    public IVectorsQuery Build()
    {
        ConstructNewInstanceIfNecessary();

        BuildWasPreviousCommand = true;

        return VectorsQuery;
    }

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyTarget(ITarget target) => Specify(target, (vectorsQuery) => vectorsQuery.Target = target, Validator.ValidateTarget);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyOrigin(IOrigin origin) => Specify(origin, (vectorsQuery) => vectorsQuery.Origin = origin, Validator.ValidateOrigin);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyEpochSelection(IEpochSelection epochSelection) => Specify(epochSelection, (vectorsQuery) => vectorsQuery.EpochSelection = epochSelection, Validator.ValidateEpochSelection);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyOutputFormat(OutputFormat outputFormat) => Specify(outputFormat, (vectorsQuery) => vectorsQuery.OutputFormat = outputFormat, Validator.ValidateOutputFormat);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyObjectDataInclusion(ObjectDataInclusion objectDataInclusion) => Specify(objectDataInclusion, (vectorsQuery) => vectorsQuery.ObjectDataInclusion = objectDataInclusion, Validator.ValidateObjectDataInclusion);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyReferencePlane(ReferencePlane referencePlane) => Specify(referencePlane, (vectorsQuery) => vectorsQuery.ReferencePlane = referencePlane, Validator.ValidateReferencePlane);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyReferenceSystem(ReferenceSystem referenceSystem) => Specify(referenceSystem, (vectorsQuery) => vectorsQuery.ReferenceSystem = referenceSystem, Validator.ValidateReferenceSystem);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyOutputUnits(OutputUnits outputUnits) => Specify(outputUnits, (vectorsQuery) => vectorsQuery.OutputUnits = outputUnits, Validator.ValidateOutputUnits);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyTableContent(VectorTableContent tableContent) => Specify(tableContent, (vectorsQuery) => vectorsQuery.TableContent = tableContent, Validator.ValidateTableContent);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyCorrection(VectorCorrection correction) => Specify(correction, (vectorsQuery) => vectorsQuery.Correction = correction, Validator.ValidateCorrection);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyTimePrecision(TimePrecision timePrecision) => Specify(timePrecision, (vectorsQuery) => vectorsQuery.TimePrecision = timePrecision, Validator.ValidateTimePrecision);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyValueSeparation(ValueSeparation valueSeparation) => Specify(valueSeparation, (vectorsQuery) => vectorsQuery.ValueSeparation = valueSeparation, Validator.ValidateValueSeparation);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyOutputLabels(OutputLabels outputLabels) => Specify(outputLabels, (vectorsQuery) => vectorsQuery.OutputLabels = outputLabels, Validator.ValidateOutputLabels);

    /// <inheritdoc/>
    public IVectorsQueryBuilder SpecifyTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion) => Specify(timeDeltaInclusion, (vectorsQuery) => vectorsQuery.TimeDeltaInclusion = timeDeltaInclusion, Validator.ValidateTimeDeltaInclusion);

    /// <summary>A mutable <see cref="IVectorsQuery"/>.</summary>
    private sealed record class MutableVectorsQuery : IVectorsQuery
    {
        public ITarget Target { get; set; }
        public IOrigin Origin { get; set; }
        public IEpochSelection EpochSelection { get; set; }

        public OutputFormat OutputFormat { get; set; } = OutputFormat.JSON;
        public ObjectDataInclusion ObjectDataInclusion { get; set; } = ObjectDataInclusion.Disable;
        public ReferencePlane ReferencePlane { get; set; } = ReferencePlane.Ecliptic;
        public ReferenceSystem ReferenceSystem { get; set; } = ReferenceSystem.ICRF;
        public OutputUnits OutputUnits { get; set; } = OutputUnits.KilometresAndSeconds;
        public VectorTableContent TableContent { get; set; } = new(VectorTableQuantities.StateVectors, VectorTableUncertainties.None);
        public VectorCorrection Correction { get; set; } = VectorCorrection.None;
        public TimePrecision TimePrecision { get; set; } = TimePrecision.Second;
        public ValueSeparation ValueSeparation { get; set; } = ValueSeparation.WhitespaceSeparation;
        public OutputLabels OutputLabels { get; set; } = OutputLabels.Disable;
        public TimeDeltaInclusion TimeDeltaInclusion { get; set; } = TimeDeltaInclusion.Disable;

        /// <inheritdoc cref="MutableVectorsQuery"/>
        /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
        /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
        /// <param name="epochSelection"><inheritdoc cref="EpochSelection" path="/summary"/></param>
        public MutableVectorsQuery(ITarget target, IOrigin origin, IEpochSelection epochSelection)
        {
            Target = target;
            Origin = origin;
            EpochSelection = epochSelection;
        }

        /// <summary>Constructs a new <see cref="MutableVectorsQuery"/>, with an initial configuration <paramref name="vectorsQuery"/>.</summary>
        /// <param name="vectorsQuery"> The initial configuration of the <see cref="MutableVectorsQuery"/>. This instance is not modified.</param>
        public MutableVectorsQuery(IVectorsQuery vectorsQuery)
        {
            Target = vectorsQuery.Target;
            Origin = vectorsQuery.Origin;
            EpochSelection = vectorsQuery.EpochSelection;

            OutputFormat = vectorsQuery.OutputFormat;
            ObjectDataInclusion = vectorsQuery.ObjectDataInclusion;
            ReferencePlane = vectorsQuery.ReferencePlane;
            ReferenceSystem = vectorsQuery.ReferenceSystem;
            OutputUnits = vectorsQuery.OutputUnits;
            TableContent = vectorsQuery.TableContent;
            Correction = vectorsQuery.Correction;
            TimePrecision = vectorsQuery.TimePrecision;
            ValueSeparation = vectorsQuery.ValueSeparation;
            OutputLabels = vectorsQuery.OutputLabels;
            TimeDeltaInclusion = vectorsQuery.TimeDeltaInclusion;
        }

        bool IEquatable<IVectorsQuery>.Equals(IVectorsQuery? other)
        {
            if (other is null)
            {
                return false;
            }

            return Target.Equals(other.Target) && Origin.Equals(other.Origin) && EpochSelection.Equals(other.EpochSelection) && OutputFormat == other.OutputFormat && ObjectDataInclusion == other.ObjectDataInclusion
                && ReferencePlane == other.ReferencePlane && ReferenceSystem == other.ReferenceSystem && OutputUnits == other.OutputUnits && TableContent.Equals(other.TableContent) && Correction == other.Correction
                && TimePrecision == other.TimePrecision && ValueSeparation == other.ValueSeparation && OutputLabels == other.OutputLabels && TimeDeltaInclusion == other.TimeDeltaInclusion;
        }
    }
}
