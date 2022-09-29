using Bank.Console.Models;
using Bank.Console.Repositories;

namespace Bank.Console.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void Deposit(Amount amount)
        {
            var status = _accountRepository.Deposit(amount.TransactionAmount, amount.TransactionDate);
            if (status)
                PrintLog($"Successfully Deposit the amount {amount.TransactionAmount}");
        }
        public void Withdraw(Amount amount)
        {
            var status = _accountRepository.Withdraw(amount.TransactionAmount, amount.TransactionDate);
            if (status)
                PrintLog($"Successfully Withdrawn the amount {amount.TransactionAmount}");
        }

        public void PrintStatement()
        {
            var statements = _accountRepository.Statements();
            System.Console.WriteLine("\n\n    **Accounts Statement**");
            System.Console.WriteLine("Date         || Amount   || Balance");
            System.Console.WriteLine("--------------------------------------");

            foreach (var item in statements)
            {
                string statement = $"{item.TransactionDate.ToShortDateString()}    || {item.TransactionAmount}     || {item.BalanceAfterTransaction}";
                System.Console.WriteLine(statement);
            }
        }
        private static void PrintLog(string message)
        {
            System.Console.WriteLine($"# {message}");
        }
    }
}
