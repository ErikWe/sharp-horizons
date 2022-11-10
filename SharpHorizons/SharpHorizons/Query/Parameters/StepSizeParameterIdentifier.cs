namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IStepSizeParameterIdentifier"/>
internal sealed record class StepSizeParameterIdentifier : IStepSizeParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "STEP_SIZE";
}
