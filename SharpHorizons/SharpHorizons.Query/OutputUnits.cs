namespace SharpHorizons.Query;

using SharpMeasures;

/// <summary>Specifies what <see cref="UnitOfLength"/> and <see cref="UnitOfTime"/> are used in the result of a query.</summary>
public enum OutputUnits
{
    /// <summary>The <see cref="OutputUnits"/> are unknown.</summary>
    Unknown,
    /// <summary><see cref="UnitOfLength.Kilometre"/> and <see cref="UnitOfTime.Second"/> are used in the result of a query.</summary>
    KilometresAndSeconds,
    /// <summary><see cref="UnitOfLength.AstronomicalUnit"/> and <see cref="UnitOfTime.Day"/> are used in the result of a query.</summary>
    AstronomicalUnitsAndDays,
    /// <summary><see cref="UnitOfLength.Kilometre"/> and <see cref="UnitOfTime.Day"/> are used in the result of a query.</summary>
    KilometresAndDays
}
