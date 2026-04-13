using FinancialAccountingApp.Interfaces;
using FinancialAccountingApp.Models.Bank;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Infrastructure.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly List<BankAccount> _bankAccounts = new List<BankAccount>();

    public void Add(BankAccount bankAccount) => _bankAccounts.Add(bankAccount);

    public BankAccount? GetById(BankAccountId bankAccountId)
    {
        return _bankAccounts.FirstOrDefault(bankAccount => bankAccount.Id == bankAccountId);
    }

    public void Update(BankAccountId bankAccountId, BankAccount bankAccount)
    {
        int index = _bankAccounts.FindIndex(account => account.Id == bankAccountId);

        if (index < 0)
        {
            throw new InvalidOperationException($"Bank account with id {bankAccountId} was not found.");
        }

        _bankAccounts[index] = bankAccount;
    }

    public void Delete(BankAccountId bankAccountId)
    {
        int index = _bankAccounts.FindIndex(account => account.Id == bankAccountId);

        if (index < 0)
        {
            throw new InvalidOperationException($"Bank account with id {bankAccountId} was not found.");
        }

        _bankAccounts.RemoveAt(index);
    }

    public IReadOnlyList<BankAccount> GetAll() => _bankAccounts.ToList();
}
