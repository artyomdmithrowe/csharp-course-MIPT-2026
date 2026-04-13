using FinancialAccountingApp.Models.Category;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Interfaces;

public interface ICategoryRepository
{
    void Add(Category category);

    Category? GetById(CategoryId categoryId);

    void Update(CategoryId categoryId, Category category);

    void Delete(CategoryId categoryId);

    IReadOnlyList<Category> GetAll();
}
