using FinancialAccountingApp.Interfaces;
using FinancialAccountingApp.Models.Bank;
using FinancialAccountingApp.Models.Ids;
using FinancialAccountingApp.Services.Factories;

namespace FinancialAccountingApp.Services.Facades;

public class BankAccountFacade
{
    private readonly IBankAccountRepository _bankAccountRepository;

    private readonly BankAccountFactory _bankAccountFactory;

    public BankAccountFacade(
        IBankAccountRepository bankAccountRepository,
        BankAccountFactory bankAccountFactory
    )
    {
        _bankAccountRepository = bankAccountRepository;
        _bankAccountFactory = bankAccountFactory;
    }

    public BankAccount Create(string name, decimal balance)
    {
        var bankAccount = _bankAccountFactory.Create(name, balance);
        _bankAccountRepository.Add(bankAccount);
        return bankAccount;
    }

    public BankAccount? GetById(BankAccountId bankAccountId) =>
        _bankAccountRepository.GetById(bankAccountId);

    public IReadOnlyList<BankAccount> GetAll() => _bankAccountRepository.GetAll();

    public void Delete(BankAccountId bankAccountId) => _bankAccountRepository.Delete(bankAccountId);

    public void Rename(BankAccountId bankAccountId, string name)
    {
        var bankAccount = GetById(bankAccountId);

        if (bankAccount is null)
        {
            throw new InvalidOperationException(
                $"Bank account with id {bankAccountId} was not found."
            );
        }

        bankAccount.Rename(name);
        _bankAccountRepository.Update(bankAccountId, bankAccount);
    }

    public void Deposit(BankAccountId bankAccountId, decimal amount)
    {
        var bankAccount = GetById(bankAccountId);

        if (bankAccount is null)
        {
            throw new InvalidOperationException(
                $"Bank account with id {bankAccountId} was not found."
            );
        }

        bankAccount.Deposit(amount);
        _bankAccountRepository.Update(bankAccountId, bankAccount);
    }

    public void Withdraw(BankAccountId bankAccountId, decimal amount)
    {
        var bankAccount = GetById(bankAccountId);

        if (bankAccount is null)
        {
            throw new InvalidOperationException(
                $"Bank account with id {bankAccountId} was not found."
            );
        }

        bankAccount.Withdraw(amount);
        _bankAccountRepository.Update(bankAccountId, bankAccount);
    }
}
