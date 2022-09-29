using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Console.Models;

namespace Bank.Console.Repositories
{
    public interface IAccountRepository
    {
        bool Deposit(double amount, DateTime transactionDate);
        bool Withdraw(double amount, DateTime transactionDate);
        IList<Transaction> Statements();
    }
}
