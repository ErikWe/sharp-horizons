namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.VectorTableContentCases;

using SharpHorizons.Query.Vectors.Table;

using System.ComponentModel;

using Xunit;

public class Initialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTableContentTuples))]
    public void Initialization_Valid_ExactMatch(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        VectorTableContent actual = new() { Quantities = quantities, Uncertainties = uncertainties };

        Assert.Equal(quantities, actual.Quantities);
        Assert.Equal(uncertainties, actual.Uncertainties);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTableContentTuples))]
    public void Initialization_Invalid_InvalidEnumArgumentException(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        var exception = Record.Exception(() => new VectorTableContent() { Quantities = quantities, Uncertainties = uncertainties });

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }
}
