using FinancialAccountingApp.Models.Bank;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Interfaces;

public interface IBankAccountRepository
{
    void Add(BankAccount bankAccount);

    BankAccount? GetById(BankAccountId bankAccountId);

    void Update(BankAccountId bankAccountId, BankAccount bankAccount);

    void Delete(BankAccountId bankAccountId);

    IReadOnlyList<BankAccount> GetAll();
}
