namespace SharpHorizons.Identity;
/// <summary>Represents a provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCProvisionalObject
{
    /// <summary>The <see cref="MPCProvisionalDesignation"/> of the object.</summary>
    public MPCProvisionalDesignation Designation { get; }

    /// <summary>Represents a provisional object { <paramref name="designation"/> } in the MPC catalogue of minor planets .</summary>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    public MPCProvisionalObject(MPCProvisionalDesignation designation)
    {
        Designation = designation;
    }
}