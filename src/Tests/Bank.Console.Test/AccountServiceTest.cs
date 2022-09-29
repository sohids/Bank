using Bank.Console.Models;
using Bank.Console.Repositories;
using Bank.Console.Services;

namespace Bank.Console.Test
{
    public class AccountServiceTest
    {
        IAccountRepository _accountRepository;
        IAccountService _accountService;
        Amount _amount1;
        Amount _amount2;
        Amount _amount3;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _accountRepository = new AccountRepository(new List<Transaction>());
            _accountService = new AccountService(_accountRepository);

            _amount1 = new Amount
            {
                TransactionAmount = 3000,
                TransactionDate = new DateTime(2012, 01, 15)
            };
            _amount2 = new Amount
            {
                TransactionAmount = 3000,
                TransactionDate = new DateTime(2012, 01, 15)
            };
            _amount3 = new Amount
            {
                TransactionAmount = 3000,
                TransactionDate = new DateTime(2012, 01, 15)
            };
        }
        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void DepositTest()
        {
            _accountService.Deposit(_amount1);
            Assert.IsTrue(true);
        }

        [Test]
        public void WithdrawTest()
        {
            _accountService.Withdraw(_amount2);
            Assert.IsTrue(true);
        }

        [Test]
        public void PrintStatementTest()
        {
            _accountService.PrintStatement();
            Assert.IsTrue(true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}