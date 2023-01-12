namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.VectorTableContentCases;

using SharpHorizons.Query.Vectors.Table;

using System.ComponentModel;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTableContentTuples))]
    public void Reinitialization_Valid_ExactMatch(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        VectorTableContent actual = new(VectorTableQuantities.None) { Quantities = quantities, Uncertainties = uncertainties };

        Assert.Equal(quantities, actual.Quantities);
        Assert.Equal(uncertainties, actual.Uncertainties);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTableContentTuples))]
    public void Reinitialization_Invalid_InvalidEnumArgumentException(VectorTableQuantities quantities, VectorTableUncertainties uncertainties)
    {
        var exception = Record.Exception(() => new VectorTableContent(VectorTableQuantities.None) { Quantities = quantities, Uncertainties = uncertainties });

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }
}
