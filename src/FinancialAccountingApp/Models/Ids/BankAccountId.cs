namespace FinancialAccountingApp.Models.Ids;

public readonly record struct BankAccountId(string Value)
{
    public static BankAccountId New() => new($"HSE-ACC-{Guid.NewGuid():N}");

    public override string ToString() => Value;
}
