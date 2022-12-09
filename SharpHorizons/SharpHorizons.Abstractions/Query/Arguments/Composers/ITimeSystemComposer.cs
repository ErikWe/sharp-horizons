namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query.Epoch;

/// <summary>Composes <see cref="ITimeSystemArgument"/> that describe <see cref="TimeSystem"/>.</summary>
public interface ITimeSystemComposer : IArgumentComposer<ITimeSystemArgument, TimeSystem> { }
