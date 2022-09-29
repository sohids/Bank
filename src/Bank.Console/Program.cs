using Bank.Console.Repositories;
using Bank.Console.Exceptions;
using Bank.Console.Services;
using Bank.Console.Models;

AccountService service = new(new AccountRepository(new List<Transaction>()));

try
{
    service.Deposit(new Amount { TransactionAmount = 1000, TransactionDate = new DateTime(2012, 01, 10) });
    service.Deposit(new Amount { TransactionAmount = 2000, TransactionDate = new DateTime(2012, 01, 13) });
    service.Withdraw(new Amount { TransactionAmount = 500, TransactionDate = new DateTime(2012, 01, 14) });
}
catch (InvalidAmountException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InsufficentBalanceException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    service.PrintStatement();
}



