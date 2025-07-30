using Xunit;
using BankAppAssignment.Bank_Model;

namespace BankAppAssignmentTestProject{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new BankUserAccount
            {
                Balance = 100,
                IsFrozen = false
            };

            // Act
            account.Deposit(50);

            // Assert
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Withdrawal_ShouldDecreaseBalance_WhenSufficientFunds()
        {
            // Arrange
            var account = new BankUserAccount
            {
                Balance = 200,
                IsFrozen = false
            };

            // Act
            account.Withdrawal(50);

            // Assert
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Withdrawal_ShouldNotProceed_WhenInsufficientFunds()
        {
            // Arrange
            var account = new BankUserAccount
            {
                Balance = 30,
                IsFrozen = false
            };

            // Act
            account.Withdrawal(100);

            // Assert
            Assert.Equal(30, account.Balance); // Balance unchanged
        }

        [Fact]
        public void Transfer_ShouldDeductFromSender()
        {
            // Arrange
            var sender = new BankUserAccount
            {
                Balance = 300,
                IsFrozen = false
            };
            var receiver = new BankUserAccount
            {
                Balance = 100,
                IsFrozen = false
            };

            // Act
            sender.Transfer("RECEIVER001", 100);
            receiver.Deposit(100);

            // Assert
            Assert.Equal(200, sender.Balance);
            Assert.Equal(200, receiver.Balance);
        }

        [Fact]
        public void Deposit_ShouldNotHappen_WhenAccountFrozen()
        {
            // Arrange
            var account = new BankUserAccount
            {
                Balance = 50,
                IsFrozen = true
            };

            // Act
            account.Deposit(100);

            // Assert
            Assert.Equal(50, account.Balance);
        }
    }
}
