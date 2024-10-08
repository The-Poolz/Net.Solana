using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Solana.Programs.Abstract;

namespace Net.Solana.Programs.Tests.Abstract;

[TestClass]
public class IntFlagTest
{
    [TestMethod]
    public void TestAllBitsSet()
    {
        IntFlag sut = new(uint.MaxValue);

        PropertyInfo[] props = sut.GetType().GetProperties();

        foreach (PropertyInfo prop in props)
        {
            MethodInfo getMethod = prop.GetGetMethod();
            Assert.IsNotNull(getMethod);

            string methodName = getMethod.ToString();
            Assert.IsNotNull(methodName);

            if (!methodName.Contains("Bit"))
                continue;

            object isBitSet = getMethod.Invoke(sut, null);
            Assert.IsNotNull(isBitSet);
            Assert.IsTrue((bool)isBitSet);
        }
    }

    [TestMethod]
    public void TestNoBitsSet()
    {
        IntFlag sut = new(uint.MinValue);

        PropertyInfo[] props = sut.GetType().GetProperties();

        foreach (PropertyInfo prop in props)
        {
            MethodInfo getMethod = prop.GetGetMethod();
            Assert.IsNotNull(getMethod);

            string methodName = getMethod.ToString();
            Assert.IsNotNull(methodName);

            if (!methodName.Contains("Bit"))
                continue;

            object isBitSet = getMethod.Invoke(sut, null);
            Assert.IsNotNull(isBitSet);
            Assert.IsFalse((bool)isBitSet);
        }
    }

    [TestMethod]
    public void TestIndividualBitSet()
    {
        PropertyInfo[] props = typeof(IntFlag).GetProperties();

        foreach (PropertyInfo prop in props)
        {
            MethodInfo getMethod = prop.GetGetMethod();
            Assert.IsNotNull(getMethod);

            string methodName = getMethod.ToString();
            Assert.IsNotNull(methodName);

            if (!methodName.Contains("Bit"))
                continue;

            byte bitNumber = byte.Parse(methodName.Split("_Bit")[1].Split("()")[0]);
            double bitMaskValue = Math.Pow(2, bitNumber);

            IntFlag sut = new((uint)bitMaskValue);

            object isBitSet = getMethod.Invoke(sut, null);
            Assert.IsNotNull(isBitSet);
            Assert.IsTrue((bool)isBitSet);
        }
    }
}