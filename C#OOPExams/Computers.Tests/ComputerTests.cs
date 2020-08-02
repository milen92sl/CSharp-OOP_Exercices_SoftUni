using System;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Stamat");
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Arrange
            var expectedName = "Gosho";
            //Act
            var computer = new Computer(expectedName);
            var actualNam = computer.Name;
            //Assert
            Assert.AreEqual(expectedName, actualNam);
            Assert.That(computer.Parts, Has.No.Null);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("    ")]
        public void ComputerNameShouldNotNullEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = new Computer(name);
            });
        }

        [Test]
        public void PriceSumOfAllParts()
        {
            //Arrange
            var ram = new Part("ram", 20);
            var hdd = new Part("hdd", 20);
            this.computer.AddPart(ram);
            this.computer.AddPart(hdd);
            var expectedTotalSum = 40;
            //Act
            var actualSum = this.computer.TotalPrice;
            //Assert
            Assert.AreEqual(expectedTotalSum, actualSum);

        }

        [Test]
        public void ShouldBeThrowExceptionIfTryAddNullParts()
        {
            //Arrange
            Part hdd = null;
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                this.computer.AddPart(hdd);
            });
        }

        [Test]
        public void TestRemoveMethodWorkCorrectly()
        {
            //Arrange
            var hdd = new Part("HDD",20);
            this.computer.AddPart(hdd);
            //Act
            //Assert
            Assert.True(computer.RemovePart(hdd));

        }

        [Test]
        public void TestGetPartMethod()
        {
            //Arrange
            var hdd = new Part("HDD", 20);
            this.computer.AddPart(hdd);
            var expectedPart = hdd;
            //Act
            var actualPart = this.computer.GetPart("HDD");
            //Assert
            Assert.AreEqual(expectedPart, actualPart);
        }

    }
}