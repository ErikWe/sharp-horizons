namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

/// <summary>Composes <see cref="ITimeZoneArgument"/> that describe a <see cref="Time"/> offset to some <see cref="TimeSystem"/>.</summary>
public interface ITimeZoneComposer : IArgumentComposer<ITimeZoneArgument, Time> { }
