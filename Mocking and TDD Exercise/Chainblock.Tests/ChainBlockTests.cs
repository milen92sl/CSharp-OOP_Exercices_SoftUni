using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chainblock.Contracts;
using Moq;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlockTests
    {
        private ITransaction transactionOne;
        private const string NotExistingTransactionId = "Invalid transaction id.";
        [SetUp]
        public void SetUp()
        {
            this.transactionOne = new Transaction(1, "A", "B", 10, TransactionStatus.Successfull);
        }

        [Test]
        public void Add_AddTransaction_ShouldChangeCountToOne()
        {
            IChainblock chainblock = new Chainblock();
            Mock<ITransaction> mockedTransaction = new Mock<ITransaction>();
            mockedTransaction.Setup(t => t.Id).Returns(1);
            ITransaction transaction = mockedTransaction.Object;

            chainblock.Add(transaction);

            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void Add_AddTransaction_ShouldAddSuccesfulyTransactionInCollection()
        {
            IChainblock chainblock = new Chainblock();

            chainblock.Add(transactionOne);

            ITransaction actualTr = chainblock.Transactions.Single();
            Assert.AreEqual(1, actualTr.Id);
        }

        [Test]
        public void Add_AddTwoTransaction_ShouldChangeCountToTwo()
        {
            IChainblock chainblock = new Chainblock();
            ITransaction transactionTwo = new Transaction(2, "C", "D", 20, TransactionStatus.Failed);

            chainblock.Add(this.transactionOne);
            chainblock.Add(transactionTwo);

            Assert.AreEqual(2, chainblock.Count);
        }

        [Test]
        public void Add_AddExistingTransactionShouldNotChangeCount()
        {
            IChainblock chainblock = new Chainblock();
            ITransaction transactionTwo = new Transaction(1, "C", "D", 20, TransactionStatus.Failed);

            chainblock.Add(this.transactionOne);
            chainblock.Add(transactionTwo);

            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]

        public void ContainsTransaction_EmptyCollection_ShoudReturnFalse()
        {
            IChainblock chainblock = new Chainblock();
            bool actualRes = chainblock.Contains(this.transactionOne);

            Assert.IsFalse(actualRes);
        }

        [Test]
        public void ContainsTransaction_NotExistingCollection_ShoudReturnFalse()
        {
            ITransaction transactionTwo = new Transaction(2, "X", "Z", 1, TransactionStatus.Aborted);
            IChainblock chainblock = new Chainblock(transactionTwo);
            bool actualRes = chainblock.Contains(this.transactionOne);

            Assert.IsFalse(actualRes);
        }

        [Test]

        public void ContainsTransaction_ExistingCollection_ShoudReturnTrue()
        {
            ITransaction transactionTwo = new Transaction(1, "X", "Z", 1, TransactionStatus.Aborted);
            IChainblock chainblock = new Chainblock(transactionTwo);
            bool actualRes = chainblock.Contains(this.transactionOne);

            Assert.IsTrue(actualRes);
        }

        [Test]

        public void ContainsId_EmptyCollection_ShoudReturnFalse()
        {
            IChainblock chainblock = new Chainblock();
            bool actualRes = chainblock.Contains(1);

            Assert.IsFalse(actualRes);
        }

        [Test]
        public void ContainsId_NotExistingCollection_ShoudReturnFalse()
        {
            ITransaction transactionTwo = new Transaction(2, "X", "Z", 1, TransactionStatus.Aborted);
            IChainblock chainblock = new Chainblock(transactionOne);
            bool actualRes = chainblock.Contains(2);

            Assert.IsFalse(actualRes);
        }

        [Test]

        public void ContainsId_ExistingCollection_ShoudReturnTrue()
        {

            IChainblock chainblock = new Chainblock(this.transactionOne);
            bool actualRes = chainblock.Contains(1);

            Assert.IsTrue(actualRes);
        }

        [Test]
        public void Coun_EmptyCollection_ShouldReturnZero()
        {
            IChainblock chainblock = new Chainblock();

            Assert.AreEqual(0, chainblock.Count);
        }

        [Test]
        public void Coun_TwoTransactions_ShouldReturnTrue()
        {

            ITransaction transactionTwo = new Transaction(2, "X", "Z", 1, TransactionStatus.Aborted);
            IChainblock chainblock = new Chainblock(transactionTwo, this.transactionOne);
            Assert.AreEqual(2, chainblock.Count);
        }

        [Test]

        public void ChangeTransactionStatus_NonExistingTransaction_ShouldThrowArgumentException()
        {
            IChainblock chainblock = new Chainblock();

            Exception ex = Assert.Throws<ArgumentException>(() =>
               chainblock.ChangeTransactionStatus(1, TransactionStatus.Aborted));

            Assert.AreEqual(NotExistingTransactionId, ex.Message);

        }

        [Test]

        public void ChangeTransactionStatus_NotExistingTransaction_ShouldThrowArgumentException()
        {
            IChainblock chainblock = new Chainblock(this.transactionOne);

            Assert.Throws<ArgumentException>(() =>
                chainblock.ChangeTransactionStatus(2, TransactionStatus.Aborted));

        }

        [Test]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorized)]

        public void ChangeTransactionStatus_ExistingTransaction_ShouldChangeStatus(TransactionStatus transactionStatus)
        {
            IChainblock chainblock = new Chainblock(this.transactionOne);
            chainblock.ChangeTransactionStatus(1, transactionStatus);

            TransactionStatus actualStatus = this.transactionOne.Status;
            Assert.AreEqual(transactionStatus, actualStatus);
        }

        [Test]

        public void RemoveTransactionById_EmptyCollection_ShouldThrowInvalidOperationException()
        {
            IChainblock chainblock = new Chainblock();

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
                chainblock.RemoveTransactionById(1));

            Assert.AreEqual(NotExistingTransactionId, ex.Message);
        }

        [Test]

        public void RemoveTransactionById_InvalidTransaction_ShouldThrowInvalidOperationException()
        {
            IChainblock chainblock = new Chainblock(this.transactionOne);

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
                chainblock.RemoveTransactionById(2));

            Assert.AreEqual(NotExistingTransactionId, ex.Message);
        }

        [Test]

        public void RemoveTransactionById_ExistingTransaction_ShouldChageCountToZero()
        {
            IChainblock chainblock = new Chainblock(this.transactionOne);

            chainblock.RemoveTransactionById(1);

            Assert.AreEqual(0, chainblock.Count);
        }

        [Test]

        public void RemoveTransactionById_AddTwoTransactionsWithExistingTransaction_ShouldChageCountToOne()
        {
            ITransaction transactionTwo =
                new Transaction(2, "X", "Z", 1, TransactionStatus.Aborted);
            IChainblock chainblock = new Chainblock(this.transactionOne, transactionTwo);

            chainblock.RemoveTransactionById(1);

            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]

        public void RemoveTransactionById_AddTwoTransactionsWithExistingTransaction_ShouldRemoveCorrectTransaction()
        {
            ITransaction transactionTwo =
                new Transaction(2, "X", "Z", 1, TransactionStatus.Aborted);
            IChainblock chainblock = new Chainblock(this.transactionOne, transactionTwo);

            int removeTrId = 1;
            chainblock.RemoveTransactionById(removeTrId);

            ITransaction actualTransaction =
                chainblock.Transactions
                    .SingleOrDefault(t => t.Id == removeTrId);

            Assert.IsNull(actualTransaction);
        }

        [Test]

        public void GetById_EmptyCollection_ShouldThrowInvalidOperationException()
        {
            IChainblock chainblock = new Chainblock();

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
                chainblock.GetById(1));

            Assert.AreEqual(NotExistingTransactionId, ex.Message);
        }

        [Test]

        public void GetById_InvalidTransaction_ShouldThrowInvalidOperationException()
        {
            IChainblock chainblock = new Chainblock(this.transactionOne);

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
                chainblock.RemoveTransactionById(2));

            Assert.AreEqual(NotExistingTransactionId, ex.Message);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(50)]
        public void GetById_ExistingTransaction_ShouldReturnCorrectTransaction(int id)
        {
            ITransaction transaction =
                new Transaction(id, "x", "z", 1, TransactionStatus.Aborted);
            IChainblock chainblock = new Chainblock(transaction);

            ITransaction actualTransaction = chainblock.GetById(id);

            Assert.AreEqual(id, actualTransaction.Id);
        }

        [Test]

        public void GetById_AddThreeTransactionsWithExistingTransaction_ShouldReturnCorrectTransaction()
        {
            ITransaction transactionTwo =
                new Transaction(2, "X", "Z", 1, TransactionStatus.Aborted);
            ITransaction transactionThree =
                new Transaction(5, "i", "p", 1, TransactionStatus.Unauthorized);
            IChainblock chainblock = new Chainblock( this.transactionOne,transactionTwo,transactionThree);

            ITransaction actualTransaction = chainblock.GetById(2);

            Assert.AreEqual(2,actualTransaction.Id);
        }
    }
}
