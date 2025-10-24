using  System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;

namespace EmjayBankApp
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string UserName { get; private set; }
        public string FullName { get; private set; }    
        private char[] Pin;
        public decimal SavingsBalance { get; private set; }
        public decimal CurrentBalance { get; private set; }

        public BankAccount(string userName, string pin, string fullName)
        {
            if (!IsValidPin(pin))
            {
                throw new ArgumentException("PIN must be exactly 4 digits.");
            }
            this.UserName = userName;
            this.FullName = fullName;
            this.Pin = pin.ToCharArray();
            this.SavingsBalance = 0.00m;
            this.CurrentBalance = 0.00m;
            this.AccountNumber = GenerateAccountNumber();
        }

        private bool IsValidPin(string pin)
        {
            return pin.Length == 4 && pin.All(char.IsDigit);
        }

        private string GenerateAccountNumber()
        {
            var random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool VerifyPin(string inputPin)
        {
            char[] inputPinChars = inputPin.ToCharArray();
            bool verified = Pin.SequenceEqual(inputPinChars);

            Array.Clear(inputPinChars, 0, inputPinChars.Length);

            return verified;
        }

        ~BankAccount()
        {
            if (Pin != null)
            {
                Array.Clear(Pin, 0, Pin.Length);
            }
        }

        public void Transfer(decimal amount, BankAccount recipient, string sourceAccountType)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Transfer amount must be positive.");
            }
            if (recipient == null)
            {
                throw new ArgumentException("Recipient account is invalid.");
            }

            if (sourceAccountType.Equals("Savings", StringComparison.OrdinalIgnoreCase))
            {
                if (amount > SavingsBalance)
                {
                    throw new InvalidOperationException("Insufficient funds in Savings account for transfer.");
                }
                SavingsBalance -= amount;
                recipient.DepositCurrent(amount); 
            }
            else if (sourceAccountType.Equals("Current", StringComparison.OrdinalIgnoreCase))
            {
                if (amount > CurrentBalance)
                {
                    throw new InvalidOperationException("Insufficient funds in Current account for transfer.");
                }
                CurrentBalance -= amount;
                recipient.DepositCurrent(amount); 
            }
            else
            {
                throw new ArgumentException("Invalid source account type specified.");
            }
        }

        public void DepositSavings(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            SavingsBalance += amount;
        }

        public void WithdrawSavings(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > SavingsBalance)
            {
                throw new InvalidOperationException("Insufficient funds in Savings account.");
            }
            SavingsBalance -= amount;
        }

        public void DepositCurrent(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            CurrentBalance += amount;
        }

        public void WithdrawCurrent(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > CurrentBalance)
            {
                throw new InvalidOperationException("Insufficient funds in Current account.");
            }
            CurrentBalance -= amount;
        }

        public decimal GetSavingsBalance()
        {
            return SavingsBalance;
        }

        public decimal GetCurrentBalance()
        {
            return CurrentBalance;
        }
    }
}