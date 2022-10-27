namespace SharpHorizons.Identification;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the provisional designation of an object in the MPC catalogue of minor planets.</summary>
/// <remarks>The provisional designation may be used also for non-provisional objects - especially if they are not given a <see cref="MPCName"/>.</remarks>
public readonly partial record struct MPCProvisionalDesignation
{
    /// <summary>The provisional designation of the object in the MPC catalogue of minor planets.</summary>
    public string Value { get; }

    /// <summary>Represents the provisional designation { <paramref name="value"/> } of an object in the MPC catalogue of minor planets.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public MPCProvisionalDesignation(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the provisional designation represented by <see langword="this"/>.</summary>
    public override string ToString() => Value;
    /// <summary>Retrieves the provisional designation represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="MPCProvisionalDesignation(string)"/>
    [SuppressMessage("Usage", "CA2225", Justification = "Available through a constructor")]
    public static implicit operator MPCProvisionalDesignation(string value) => new(value);

    /// <summary>Retrieves the provisional designation represented by <paramref name="provisionalDesignation"/>.</summary>
    /// <param name="provisionalDesignation"><inheritdoc cref="MPCName" path="/summary"/></param>
    public static implicit operator string(MPCProvisionalDesignation provisionalDesignation) => provisionalDesignation.Value;
}