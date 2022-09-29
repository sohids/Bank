using Bank.Console.Exceptions;
using Bank.Console.Models;
using Bank.Console.Repositories;

namespace Bank.Console.Test
{
    public class AccountRepositoryTest
    {
        IAccountRepository _accountRepository;
        Amount _amount1;
        Amount _amount2;
        Amount _amount4;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _accountRepository = new AccountRepository(new List<Transaction>());

            _amount1 = new Amount
            {
                TransactionAmount = 1000,
                TransactionDate = new DateTime(2012, 01, 10)
            };
            _amount2 = new Amount
            {
                TransactionAmount = 2000,
                TransactionDate = new DateTime(2012, 01, 13)
            };
            _amount4 = new Amount
            {
                TransactionAmount = -500,
                TransactionDate = new DateTime(2012, 01, 14)
            };
        }
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Deposit_NonNegetiveAmount_Deposit()
        {
            var result = _accountRepository.Deposit(_amount1.TransactionAmount, _amount2.TransactionDate);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Deposit_NegativeAmount_ThrowException()
        {
            Assert.Throws<InvalidAmountException>(
                () => _accountRepository.
                Deposit(_amount4.TransactionAmount, _amount4.TransactionDate));
        }

        [Test]
        public void Withdraw_SufficientBalance_WindrawAmount()
        {
            _accountRepository.Deposit(5000, new DateTime(2012, 01, 14));
            var result = _accountRepository.Withdraw(3000, DateTime.Now);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Withdraw_InSufficientBalance_WindrawAmount()
        {
            Assert.Throws<InsufficentBalanceException>(
                () => _accountRepository.
                Withdraw(_amount2.TransactionAmount, _amount2.TransactionDate));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}