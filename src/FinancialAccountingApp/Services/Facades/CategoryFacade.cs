using FinancialAccountingApp.Interfaces;
using FinancialAccountingApp.Models.Category;
using FinancialAccountingApp.Models.Enums;
using FinancialAccountingApp.Models.Ids;
using FinancialAccountingApp.Services.Factories;

namespace FinancialAccountingApp.Services.Facades;

public class CategoryFacade
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly CategoryFactory _categoryFactory;

    public CategoryFacade(ICategoryRepository categoryRepository, CategoryFactory categoryFactory)
    {
        _categoryRepository = categoryRepository;
        _categoryFactory = categoryFactory;
    }

    public Category Create(CategoryType type, string name)
    {
        var category = _categoryFactory.Create(type, name);
        _categoryRepository.Add(category);
        return category;
    }

    public Category? GetById(CategoryId categoryId) => _categoryRepository.GetById(categoryId);

    public IReadOnlyList<Category> GetAll() => _categoryRepository.GetAll();

    public void Delete(CategoryId categoryId) => _categoryRepository.Delete(categoryId);

    public void Rename(CategoryId categoryId, string name)
    {
        var category = GetById(categoryId);

        if (category is null)
        {
            throw new InvalidOperationException($"Category with id {categoryId} was not found.");
        }

        category.Rename(name);
        _categoryRepository.Update(categoryId, category);
    }
}
