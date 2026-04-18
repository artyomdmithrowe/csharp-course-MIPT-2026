using FinancialAccountingApp.Models.Category;
using FinancialAccountingApp.Models.Enums;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Services.Factories;

public class CategoryFactory
{
    public Category Create(CategoryType type, string name)
    {
        return new Category(CategoryId.New(), type, name);
    }
}
