﻿namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as an <see cref="IEphemeris{TEntry}"/> of <see cref="IObjectVelocityUncertaintyXYZ"/>.</summary>
public interface IObjectVelocityUncertaintyXYZEphemerisInterpreter : IVectorsEphemerisInterpreter<IObjectVelocityUncertaintyXYZ> { }
