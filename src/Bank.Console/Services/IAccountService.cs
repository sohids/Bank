using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Console.Models;

namespace Bank.Console.Services
{
    public interface IAccountService
    {
        void Deposit(Amount amount);
        void Withdraw(Amount amount);
        void PrintStatement();
    }
}
