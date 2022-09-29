using System.Data;
using Bank.Console.Enums;
using Bank.Console.Exceptions;
using Bank.Console.Models;

namespace Bank.Console.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private static double _currentBalance = 0;
        private readonly IList<Transaction> _transactions;
        public AccountRepository(IList<Transaction> transactions)
        {
            _transactions = transactions;
        }
        public bool Deposit(double amount, DateTime transactionDate)
        {
            if (amount < 0)
                throw new InvalidAmountException("Invalid Amount");

            _currentBalance += amount;
            SaveTransaction(amount, TransactionType.Credit, transactionDate);
            return true;
        }
        public bool Withdraw(double amount, DateTime transactionDate)
        {
            if (_currentBalance < amount)
                throw new InsufficentBalanceException($"# [Your account doesn't have sufficent balance cannot withdraw the money- {amount}]");

            _currentBalance -= amount;
            SaveTransaction(amount, TransactionType.Debit, transactionDate);
            return true;
        }
        public IList<Transaction> Statements()
        {
            return _transactions.OrderByDescending(x => x.TransactionDate).ToList();
        }

        private void SaveTransaction(double amount, TransactionType type,
            DateTime transactionDate)
        {
            var transaction = new Transaction()
            {
                TransactionDate = transactionDate,
                BalanceAfterTransaction = _currentBalance,
            };

            switch (type)
            {
                case TransactionType.Debit:
                    transaction.TransactionAmount = -amount;
                    break;
                case TransactionType.Credit:
                    transaction.TransactionAmount = amount;
                    break;
            }
            _transactions.Add(transaction);
        }
    }
}
