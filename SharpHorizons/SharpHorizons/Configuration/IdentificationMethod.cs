namespace SharpHorizons.Configuration;

/// <summary>Describes how an object is identified in the JPL Horizons database.</summary>
public enum IdentificationMethod
{
    /// <summary>The object is not identified.</summary>
    None = 0,
    /// <summary>The object is identified using a name.</summary>
    Name = 1,
    /// <summary>The object is identified using a designation.</summary>
    Designation = 2,
    /// <summary>The object is identified using an ID.</summary>
    ID = 3
}
