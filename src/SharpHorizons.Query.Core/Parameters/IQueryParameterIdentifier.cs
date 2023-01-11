namespace SharpHorizons.Query.Parameters;

/// <summary>Represents the identifier of a parameter in a query.</summary>
public interface IQueryParameterIdentifier
{
    /// <summary>The identifier of the parameter in a query.</summary>
    public abstract string Identifier { get; }
}
