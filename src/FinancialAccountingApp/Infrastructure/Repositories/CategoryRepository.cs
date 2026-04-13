using FinancialAccountingApp.Interfaces;
using FinancialAccountingApp.Models.Category;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories = new List<Category>();

    public void Add(Category category) => _categories.Add(category);

    public Category? GetById(CategoryId categoryId)
    {
        return _categories.FirstOrDefault(category => category.Id == categoryId);
    }

    public void Update(CategoryId categoryId, Category category)
    {
        int index = _categories.FindIndex(currentCategory => currentCategory.Id == categoryId);

        if (index < 0)
        {
            throw new InvalidOperationException($"Category with id {categoryId} was not found.");
        }

        _categories[index] = category;
    }

    public void Delete(CategoryId categoryId)
    {
        int index = _categories.FindIndex(currentCategory => currentCategory.Id == categoryId);

        if (index < 0)
        {
            throw new InvalidOperationException($"Category with id {categoryId} was not found.");
        }

        _categories.RemoveAt(index);
    }

    public IReadOnlyList<Category> GetAll() => _categories.ToList();
}
