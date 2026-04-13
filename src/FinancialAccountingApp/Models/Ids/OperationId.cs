namespace FinancialAccountingApp.Models.Ids;

public readonly record struct OperationId(string Value)
{
    public static OperationId New() => new($"HSE-OPE-{Guid.NewGuid():N}");

    public override string ToString() => Value;
}
