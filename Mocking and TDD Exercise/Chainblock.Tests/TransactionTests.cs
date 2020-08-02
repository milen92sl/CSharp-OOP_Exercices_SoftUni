using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {

        [Test]
        public void Constructor_ValidArguments_ShouldSetValidDataToProperties()
        {
            ITransaction transaction = 
                new Transaction(1, "Peter", "George", 50, TransactionStatus.Successfull);

            Assert.AreEqual(1, transaction.Id);
            Assert.AreEqual("Peter", transaction.From);
            Assert.AreEqual("George", transaction.To);
            Assert.AreEqual(50, transaction.Amount);
            Assert.AreEqual(TransactionStatus.Successfull, transaction.Status);
        }
    }
}
