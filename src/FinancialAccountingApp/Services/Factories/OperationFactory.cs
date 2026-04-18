using FinancialAccountingApp.Models.Category;
using FinancialAccountingApp.Models.Enums;
using FinancialAccountingApp.Models.Ids;
using FinancialAccountingApp.Models.Operation;

namespace FinancialAccountingApp.Services.Factories;

public class OperationFactory
{
    public Operation Create(
        OperationType type,
        BankAccountId bankAccountId,
        Category category,
        decimal amount,
        DateTime date,
        string? description = null)
    {
        bool isCompatible =
            (type == OperationType.Income && category.Type == CategoryType.Income) ||
            (type == OperationType.Expense && category.Type == CategoryType.Expense);

        if (!isCompatible)
        {
            throw new ArgumentException("Operation type must match category type.");
        }

        return new Operation(
            OperationId.New(),
            type,
            bankAccountId,
            category.Id,
            amount,
            date,
            description);
    }
}
