using FinancialAccountingApp.Models.Ids;
using FinancialAccountingApp.Models.Operation;

namespace FinancialAccountingApp.Interfaces;

public interface IOperationRepository
{
    void Add(Operation operation);

    Operation? GetById(OperationId operationId);

    void Update(OperationId operationId, Operation operation);

    void Delete(OperationId operationId);

    IReadOnlyList<Operation> GetAll();

    IReadOnlyList<Operation> GetByBankAccountId(BankAccountId bankAccountId);

    IReadOnlyList<Operation> GetByCategoryId(CategoryId categoryId);

    IReadOnlyList<Operation> GetByPeriod(DateTime from, DateTime to);
}
