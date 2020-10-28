using NUnit.Framework;

namespace UnitTesting.Tests
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount bankAccount;

        [SetUp]
        public void CreateBankAccount()
        {
            bankAccount = new BankAccount(100m);
        }

        [TearDown]
        public void NullBankAccount()
        {
            bankAccount = null;
        }

        [Test]
        public void TestNewBankAccount()
        {
            Assert.That(bankAccount.Balance, Is.EqualTo(100m), 
                "Test input balance of bank account.");
        }

        [Test]
        public void TestNewBankAccountWithNegativeBalance()
        {
            Assert.That(() => new BankAccount(-100m), 
                Throws.ArgumentException
                .With.Message.EqualTo("Balance cannot be negative."));
        }

        [Test]
        public void TestDeposit()
        {
            bankAccount.Deposit(100m);

            Assert.That(bankAccount.Balance, Is.EqualTo(200m), "Test deposit.");
        }

        [Test]
        public void TestDepositWithNegativeSum()
        {
            Assert.That(() => bankAccount.Deposit(-50m), 
                Throws.ArgumentException
                .With.Message
                .EqualTo("Sum must be bigger than zero."));
        }

        [Test]
        public void TestWithdraw()
        {
            decimal currentBankBalance = bankAccount.Balance;
            decimal withdrawSum = 43m;

            decimal ballanceAfterWithdraw = currentBankBalance - withdrawSum;

            bankAccount.Withdraw(withdrawSum);

            Assert.That(bankAccount.Balance, Is.EqualTo(ballanceAfterWithdraw));
        }

        [Test]
        public void TestWithdawMoreThanBalance()
        {
            Assert.That(() => bankAccount.Withdraw(500), Throws
                .ArgumentException.With.Message
                .EqualTo("Balance cannot be negative."));
        }
    }
}
