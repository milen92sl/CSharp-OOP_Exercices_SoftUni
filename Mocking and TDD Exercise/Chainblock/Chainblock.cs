using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;
        private const string NotExistingTransactionId = "Invalid transaction id.";
        public Chainblock(params ITransaction[] transactions)
        {
            this.transactions = transactions.ToList();
        }
        public int Count => this.transactions.Count;
        public IReadOnlyCollection<ITransaction> Transactions => this.transactions.ToList().AsReadOnly();

        public void Add(ITransaction tx)
        {
            if (this.transactions.All(t => t.Id != tx.Id))
            {
                this.transactions.Add(tx);
            }
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(ITransaction tx)
        {
            return this.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction =
                this.GetTransactionById(id);

            if (transaction == null)
            {
                throw new ArgumentException(NotExistingTransactionId);
            }
            transaction.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transaction = this.GetTransactionById(id);

            if (transaction == null)
            {
                throw new InvalidOperationException(NotExistingTransactionId);
            }
            this.transactions.Remove(transaction);

        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.GetTransactionById(id);

            if (transaction == null)
            {
                throw new InvalidOperationException(NotExistingTransactionId);
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        private ITransaction GetTransactionById(int id) =>
            this.transactions.FirstOrDefault(t => t.Id == id);

    }
}
