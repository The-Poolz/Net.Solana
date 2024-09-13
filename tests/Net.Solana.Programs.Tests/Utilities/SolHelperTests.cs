using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Solana.Programs.Utilities;

namespace Net.Solana.Programs.Tests.Utilities;

[TestClass]
public class SolHelperTests
{

    [TestMethod]
    public void TestSolHelper()
    {
        Assert.AreEqual((ulong)168855000000, SolHelper.ConvertToLamports(168.855M));
        Assert.AreEqual(168.855M, SolHelper.ConvertToSol((ulong)168855000000));
        Assert.AreEqual(168.855000000M, SolHelper.ConvertToSol((ulong)168855000000));
    }

}