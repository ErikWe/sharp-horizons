namespace SharpHorizons.Query;

using SharpMeasures;

/// <summary>Specifies what <see cref="UnitOfLength"/> and <see cref="UnitOfTime"/> are used to express values in a query result.</summary>
public enum OutputUnits
{
    /// <summary>The <see cref="OutputUnits"/> are unknown.</summary>
    Unknown,
    /// <summary><see cref="UnitOfLength.Kilometre"/> and <see cref="UnitOfTime.Second"/>.</summary>
    KilometresAndSeconds,
    /// <summary><see cref="UnitOfLength.AstronomicalUnit"/> and <see cref="UnitOfTime.Day"/>.</summary>
    AstronomicalUnitsAndDays,
    /// <summary><see cref="UnitOfLength.Kilometre"/> and <see cref="UnitOfTime.Day"/>.</summary>
    KilometresAndDays
}
