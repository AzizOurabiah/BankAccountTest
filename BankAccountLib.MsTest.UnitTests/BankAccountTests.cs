using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankAccountLib.MsTest.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [TestCategory("Credit")]
        public void Credit_ValidAmount_IncrementBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1100;

            // Act
            sut.Credit(100);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Debit")]
        public void Debit_ValidAmount_DecrementBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 900;

            // Act
            sut.Debit(100);

            // Assert
            Assert.AreEqual(expected, sut.Balance, "Check Debit method impl");
        }
        #region MaRegion
        /// <summary>
        /// Should the code just return when the Amount = 0 ?
        /// It depends on the use case.
        /// </summary>
        [TestMethod]
        [TestCategory("Credit")]
        public void Credit_AmountZero_NotChangeBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1000;

            // Act
            sut.Credit(0);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        [TestMethod]
        [Ignore("Bad test case to catch Exception inside the test method")]
        [TestCategory("Debit")]
        public void Debit_AmountBiggerThanBalance_ThrowsException_()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1000;
            var actual = 0.0;

            // Act
            try
            {
                sut.Debit(2000);
            }
            catch (ArgumentOutOfRangeException e)
            {
                actual = sut.Balance;
                // Assert
                Assert.AreEqual("amount", e.ParamName);
                Assert.AreEqual(expected, actual);
            }
            Assert.Fail("Test Failed !");
        }

        [TestMethod]
        [TestCategory("Credit")]
        public void Credit_MaxAmount_ThrowsException()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => sut.Credit(int.MaxValue));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestCategory("Debit")]
        public void Debit_AmountBiggerThanBalance_ThrowsException()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);

            // Act
            sut.Debit(2000);

            // Assert
            // the attribute [ExpectedException(typeof(ArgumentOutOfRangeException))]
        }

        [DataRow(1000, 100, 1100)]
        [DataRow(1000, 200, 1200)]
        [DataRow(1000, 300, 1300)]
        [DataTestMethod]
        [TestCategory("Credit")]
        public void Credit_ValidAmount_IncrementBalance_DataRow(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [TestCategory("Credit")]
        public void Credit_ValidAmount_IncrementBalance_DynamicData(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { 1, 1, 2 },
                new object[] { 14, 1, 15 },
                new object[] { 14, 1, 15 }
            };
        }

        [TestInitialize]
        public void RunBeforeTest()
        {
        }

        [TestCleanup]
        public void RunAfterTest()
        {
        }
    }
}
