using System;
using System.Collections.Generic;

namespace INStock.Tests
{
    using INStock.Contracts;
    using Moq;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class TrackingSystemTests
    {
        private IList<IProduct> repo;
        private Mock<IProduct> product;
        private TrackingSystem ts;
        
        [SetUp]
        public void Initialize()
        {
            repo = new List<IProduct>();
            product = new Mock<IProduct>();
            ts = new TrackingSystem(repo);
            product.Setup(p => p.Label).Returns("Beer");
        }
    
        [Test]
        public void ProductMustBeInSystemAfterAdd()
        {
            ts.Add(product.Object);

            Assert.That(ts[0].Label, Is.EqualTo("Beer"));
        }

        [Test]
        public void SystemMustContainProduct()
        {
            repo.Add(product.Object);

            bool containsProduct = ts.Contains(product.Object);

            Assert.That(containsProduct, Is.EqualTo(true));
        }

        [Test]
        public void SystemMustCountProducts()
        {
            repo.Add(product.Object);

            int count = ts.Count;

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]

        public void LabelMustBeUnique()
        {
            ts.Add(product.Object);

            Assert.That(() => ts.Add(product.Object),
                Throws.ArgumentException.With.Message.EqualTo("Product already exists"));
        }

        [Test]
        public void SystemMustRaseExceptionIfIndexLessThanZero()
        {
            Assert.That(() => ts.Find(-1)
                , Throws.InstanceOf<IndexOutOfRangeException>()
                    .With.Message.EqualTo("No such index"));
        }

        [Test]

        public void SysteMustFindProduct()
        {
            repo.Add(product.Object);
            IProduct foundProduct = ts.Find(1);

            Assert.That(foundProduct, Is.EqualTo(product.Object));
        }
    }
}
