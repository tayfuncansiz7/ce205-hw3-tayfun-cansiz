using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ce205_hw3_open_addressing.Class1;
using static ce205_hw3_hashing_with_chaining.Class1;

namespace ce205_hw3_test_cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Hashing_With_Chaining_Test1()
        {
            HashSc hashSc = new HashSc();
            hashSc.OpenTable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin luctus vulputate urna et consectetur. Suspendisse.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashSc.Insert(i + 1, LoremArray[i]);
            string result = hashSc.Retrieve(2);
            string expected = "ipsum";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Open_Addressing_LinearProbing_Test1()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Sed eu tristique est. Class aptent taciti sociosqu ad litora.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataLinearProbing(1);
            string expected = "Sed";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_QuadraticProbing_Test1()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Vestibulum et urna velit. Aenean vitae porttitor mi. Phasellus at.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.QuadraticInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataQuadraticProbing(1);
            string expected = "Vestibulum";
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Open_Addressing_DoubleHashing_Test1()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Donec augue arcu, venenatis interdum blandit at, pretium sed arcu.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.DoubleHashing(i + 1, LoremArray[i]);
            string result = hashOps.GetDataDoubleHashing(8);
            string expected = "pretium";
            Assert.AreEqual(expected, result);
        }

    }
}
