using FinancialAccountingApp.Models.Enums;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Models.Operation;

public class Operation
{
    private decimal _amount;
    private string _description = string.Empty;

    public OperationId Id { get; }

    public OperationType Type { get; }

    public BankAccountId BankAccountId { get; }

    public CategoryId CategoryId { get; }

    public DateTime Date { get; }

    public decimal Amount
    {
        get => _amount;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Operation amount must be greater than zero.",
                    nameof(value)
                );
            }

            _amount = value;
        }
    }

    public string Description
    {
        get => _description;
        private set
        {
            if (value is null)
            {
                _description = string.Empty;
            }
            else
            {
                _description = value;
            }
        }
    }

    public Operation(
        OperationId id,
        OperationType type,
        BankAccountId bankAccountId,
        CategoryId categoryId,
        decimal amount,
        DateTime date,
        string? description = null
    )
    {
        Id = id;
        Type = type;
        BankAccountId = bankAccountId;
        CategoryId = categoryId;
        Date = date;
        Amount = amount;
        Description = description;
    }

    public void ChangeDescription(string? description)
    {
        Description = description;
    }

    public override string ToString() =>
        $"{Type}: {Amount} | Account: {BankAccountId} | Category: {CategoryId} | Date: {Date:yyyy-MM-dd} | Description: {Description}";
}
