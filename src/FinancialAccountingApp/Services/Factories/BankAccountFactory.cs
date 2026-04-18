using FinancialAccountingApp.Models.Bank;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Services.Factories;

public class BankAccountFactory
{
    public BankAccount Create(string name, decimal balance)
    {
        return new BankAccount(BankAccountId.New(), name, balance);
    }
}
