namespace SharpHorizons.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

/// <summary>Describes instantiation of <see cref="IVectorsQuery"/>.</summary>
/// <param name="target"><inheritdoc cref="IVectorsQuery.Target" path="/summary"/></param>
/// <param name="origin"><inheritdoc cref="IVectorsQuery.Origin" path="/summary"/></param>
/// <param name="epochs"><inheritdoc cref="IVectorsQuery.Epochs" path="/summary"/></param>
public delegate IVectorsQuery VectorsQueryInstantiation(ITarget target, IOrigin origin, IEpochSelection epochs);