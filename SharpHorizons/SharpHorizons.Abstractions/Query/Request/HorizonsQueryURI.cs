namespace SharpHorizons.Query.Request;

using SharpHorizons.Query.Arguments;

using System;

/// <summary>Describes the <see cref="Uri"/>-representation of a <see cref="IQueryArgumentSet"/>.</summary>
public readonly record struct HorizonsQueryURI
{
    /// <summary>The <see cref="Uri"/> composed from a <see cref="IQueryArgumentSet"/>.</summary>
    public Uri Value { get; }

    /// <summary><inheritdoc cref="HorizonsQueryURI" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public HorizonsQueryURI(Uri value)
    {
        ArgumentNullException.ThrowIfNull(value);

        Value = value;
    }

    /// <summary>Retrieves the identifier represented by <see langword="this"/>.</summary>
    public override string ToString() => Value.ToString();

    /// <inheritdoc cref="HorizonsQueryURI(Uri)"/>
    /// <exception cref="ArgumentNullException"/>
    public static implicit operator HorizonsQueryURI(Uri value) => new(value);

    /// <summary>Retrieves the <see cref="Uri"/> represented by <paramref name="queryURI"/>.</summary>
    /// <param name="queryURI"><inheritdoc cref="HorizonsQueryURI" path="/summary"/></param>
    public static implicit operator Uri(HorizonsQueryURI queryURI) => queryURI.Value;
}
