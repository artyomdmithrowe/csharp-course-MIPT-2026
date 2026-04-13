using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Models.Bank;

public class BankAccount
{
    private string _name = string.Empty;
    private decimal _balance;

    public BankAccountId Id { get; }

    public string Name
    {
        get => _name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Bank account name cannot be empty.", nameof(value));
            }

            _name = value;
        }
    }

    public decimal Balance
    {
        get => _balance;

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Bank account balance cannot be negative.", nameof(value));
            }

            _balance = value;
        }
    }

    public BankAccount(BankAccountId id, string name, decimal balance)
    {
        Id = id;
        Name = name;
        Balance = balance;
    }

    public void Rename(string name) => Name = name;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdraw amount must be greater than zero.", nameof(amount));
        }

        Balance -= amount;
    }

    public override string ToString() => $"{Name} ({Id}) - Balance: {Balance}";
}
