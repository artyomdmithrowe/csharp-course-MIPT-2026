namespace FinancialAccountingApp.Models.Ids;

public readonly record struct CategoryId(string Value)
{
    public static CategoryId New() => new($"HSE-CAT-{Guid.NewGuid():N}");

    public override string ToString() => Value;
}
