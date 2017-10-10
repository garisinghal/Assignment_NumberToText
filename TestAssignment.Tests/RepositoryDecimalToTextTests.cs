using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAssignment.Business;
using TestAssignment.Models;

namespace TestAssignment.Tests
{
    [TestClass]
    public class RepositoryDecimalToTextTests
    { 
            // For dispaying Hundreds
            [TestMethod()]
            public void GetInformationTest()
            {
                //Arrange 
                string name = "Garima";
                decimal amount = Convert.ToDecimal("102.55");

                // Act
                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                //Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ONE HUNDRED TWO DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);

            }

            // For dispaying Tens
            [TestMethod()]
            public void GetInformationTestForTens()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("10.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("TEN DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);

            }

            // For dispaying Thousands
            [TestMethod()]
            public void GetInformationTestForThousands()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("1001.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ONE THOUSAND ONE DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);
            }

            // For dispaying TenThousands
            [TestMethod()]
            public void GetInformationTestForTenThousands()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("10001.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("TEN THOUSAND ONE DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);
            }

            // For dispaying Higher Thousand
            [TestMethod()]
            public void GetInformationTestHigherThousand()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("100001.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ONE HUNDRED THOUSAND ONE DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);
            }

            // For dispaying OneMillion
            [TestMethod()]
            public void GetInformationTestForOneMillion()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("1000001.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ONE MILLION ONE DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);
            }

            // For dispaying Ten Million
            [TestMethod()]
            public void GetInformationTestForTenMillion()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("10000001.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("TEN MILLION ONE DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);
            }

            // For dispaying HigherMillion
            [TestMethod()]
            public void GetInformationTestHigherMillion()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("100000001.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ONE HUNDRED MILLION ONE DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);
            }

            // For dispaying Billion
            [TestMethod()]
            public void GetInformationTestBillion()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("1000000001.55");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ONE BILLION ONE DOLLARS AND FIFTY FIVE CENTS", info.MyCurrentcyNumberText);
            }

            // For dispaying no Cents
            [TestMethod()]
            public void GetInformationTestNoCents()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("123");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ONE HUNDRED TWENTY THREE DOLLARS AND ZERO CENTS", info.MyCurrentcyNumberText);
            }

            // For no whole number
            [TestMethod()]
            public void GetInformationTestNoWholeNumber()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("0.123");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ZERO DOLLARS AND TWELVE CENTS", info.MyCurrentcyNumberText);
            }

            //For no 0 value
            [TestMethod()]
            public void GetInformationTestZero()
            {
                string name = "Garima";
                decimal amount = Convert.ToDecimal("0.0");

                RepositoryDecimalToText _testTens = new RepositoryDecimalToText();
                InformationModel info = _testTens.GetInformation(name, amount);

                // Assert
                Assert.IsNotNull(info);
                Assert.AreEqual("Garima", info.MyName);
                Assert.AreEqual("ZERO DOLLARS AND ZERO CENTS", info.MyCurrentcyNumberText);
            }
        }
}
