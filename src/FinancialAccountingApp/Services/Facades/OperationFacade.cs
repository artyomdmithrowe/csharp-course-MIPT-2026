using FinancialAccountingApp.Interfaces;
using FinancialAccountingApp.Models.Enums;
using FinancialAccountingApp.Models.Ids;
using FinancialAccountingApp.Models.Operation;
using FinancialAccountingApp.Services.Factories;

namespace FinancialAccountingApp.Services.Facades;

public class OperationFacade
{
    private readonly IOperationRepository _operationRepository;

    private readonly IBankAccountRepository _bankAccountRepository;

    private readonly ICategoryRepository _categoryRepository;

    private readonly OperationFactory _operationFactory;

    public OperationFacade(
        IOperationRepository operationRepository,
        IBankAccountRepository bankAccountRepository,
        ICategoryRepository categoryRepository,
        OperationFactory operationFactory
    )
    {
        _operationRepository = operationRepository;
        _bankAccountRepository = bankAccountRepository;
        _categoryRepository = categoryRepository;
        _operationFactory = operationFactory;
    }

    public Operation Create(
        OperationType type,
        BankAccountId bankAccountId,
        CategoryId categoryId,
        decimal amount,
        DateTime date,
        string? description = null
    )
    {
        var bankAccount = _bankAccountRepository.GetById(bankAccountId);

        if (bankAccount is null)
        {
            throw new InvalidOperationException(
                $"Bank account with id {bankAccountId} was not found."
            );
        }

        var category = _categoryRepository.GetById(categoryId);

        if (category is null)
        {
            throw new InvalidOperationException($"Category with id {categoryId} was not found.");
        }

        var operation = _operationFactory.Create(
            type,
            bankAccountId,
            category,
            amount,
            date,
            description
        );

        if (type == OperationType.Income)
        {
            bankAccount.Deposit(amount);
        }
        else
        {
            bankAccount.Withdraw(amount);
        }

        _bankAccountRepository.Update(bankAccountId, bankAccount);
        _operationRepository.Add(operation);

        return operation;
    }

    public Operation? GetById(OperationId operationId) => _operationRepository.GetById(operationId);

    public IReadOnlyList<Operation> GetAll() => _operationRepository.GetAll();

    public IReadOnlyList<Operation> GetByBankAccountId(BankAccountId bankAccountId) =>
        _operationRepository.GetByBankAccountId(bankAccountId);

    public IReadOnlyList<Operation> GetByCategoryId(CategoryId categoryId) =>
        _operationRepository.GetByCategoryId(categoryId);

    public IReadOnlyList<Operation> GetByPeriod(DateTime from, DateTime to) =>
        _operationRepository.GetByPeriod(from, to);

    public void ChangeDescription(OperationId operationId, string? description)
    {
        var operation = GetById(operationId);

        if (operation is null)
        {
            throw new InvalidOperationException($"Operation with id {operationId} was not found.");
        }

        operation.ChangeDescription(description);
        _operationRepository.Update(operationId, operation);
    }

    public void Delete(OperationId operationId)
    {
        var operation = GetById(operationId);

        if (operation is null)
        {
            throw new InvalidOperationException($"Operation with id {operationId} was not found.");
        }

        var bankAccount = _bankAccountRepository.GetById(operation.BankAccountId);

        if (bankAccount is null)
        {
            throw new InvalidOperationException(
                $"Bank account with id {operation.BankAccountId} was not found."
            );
        }

        if (operation.Type == OperationType.Income)
        {
            bankAccount.Withdraw(operation.Amount);
        }
        else
        {
            bankAccount.Deposit(operation.Amount);
        }

        _bankAccountRepository.Update(bankAccount.Id, bankAccount);
        _operationRepository.Delete(operationId);
    }
}
