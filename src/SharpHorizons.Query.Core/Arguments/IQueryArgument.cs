namespace SharpHorizons.Query.Arguments;

/// <summary>Represents the value of a parameter in a query.</summary>
public interface IQueryArgument
{
    /// <summary>The value of the parameter in a query.</summary>
    public abstract string Value { get; }
}
