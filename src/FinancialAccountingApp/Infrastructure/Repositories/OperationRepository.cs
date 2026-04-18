using FinancialAccountingApp.Interfaces;
using FinancialAccountingApp.Models.Ids;
using FinancialAccountingApp.Models.Operation;

namespace FinancialAccountingApp.Infrastructure.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly List<Operation> _operations = new List<Operation>();

    public void Add(Operation operation) => _operations.Add(operation);

    public Operation? GetById(OperationId operationId)
    {
        return _operations.FirstOrDefault(operation => operation.Id == operationId);
    }

    public void Update(OperationId operationId, Operation operation)
    {
        int index = _operations.FindIndex(currentOperation => currentOperation.Id == operationId);

        if (index < 0)
        {
            throw new InvalidOperationException($"Operation with id {operationId} was not found.");
        }

        _operations[index] = operation;
    }

    public void Delete(OperationId operationId)
    {
        int index = _operations.FindIndex(currentOperation => currentOperation.Id == operationId);

        if (index < 0)
        {
            throw new InvalidOperationException($"Operation with id {operationId} was not found.");
        }

        _operations.RemoveAt(index);
    }

    public IReadOnlyList<Operation> GetAll() => _operations.ToList();

    public IReadOnlyList<Operation> GetByBankAccountId(BankAccountId bankAccountId)
    {
        return _operations.Where(operation => operation.BankAccountId == bankAccountId).ToList();
    }

    public IReadOnlyList<Operation> GetByCategoryId(CategoryId categoryId)
    {
        return _operations.Where(operation => operation.CategoryId == categoryId).ToList();
    }

    public IReadOnlyList<Operation> GetByPeriod(DateTime from, DateTime to)
    {
        return _operations
            .Where(operation => operation.Date >= from && operation.Date <= to)
            .ToList();
    }
}
