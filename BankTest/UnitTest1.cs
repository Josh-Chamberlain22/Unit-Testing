using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;
namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                // act  
                account.Debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            // assert is handled by ExpectedException
            Assert.Fail("No exception was thrown.");
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
             
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
             
        }
        [TestMethod]
        public void Credit_WhenAccountIsFrozen()
        {
            double Balance = 11.99;
            double CreditAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Alden", Balance);
            account.ToggleFreeze();
            try
            {
                account.Credit(CreditAmount);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAccountFrozenMessage);
                return;
            }
            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void Credit_WhenAmountIsNegative()
        {
            double Balance = 11.99;
            double CreditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Chamberlain", Balance);
            try
            {
                account.Credit(CreditAmount);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
        [TestMethod]
        public void Good_Credit()
        {
            double Balance = 100.00;
            double CreditAmount = 15.00;
            BankAccount account = new BankAccount("Mr. Newbill", Balance);

            try
            {
                account.Credit(CreditAmount);    
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "The amount you are trying to get is invalid.");
                return;
            }
            
        }
    }
}
