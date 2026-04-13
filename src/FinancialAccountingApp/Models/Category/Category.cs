using FinancialAccountingApp.Models.Enums;
using FinancialAccountingApp.Models.Ids;

namespace FinancialAccountingApp.Models.Category;

public class Category
{
    private string _name = string.Empty;

    public CategoryId Id { get; }

    public CategoryType Type { get; private set; }

    public string Name
    {
        get => _name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Category name cannot be empty.", nameof(value));
            }

            _name = value;
        }
    }

    public Category(CategoryId id, CategoryType type, string name)
    {
        Id = id;
        Type = type;
        Name = name;
    }

    public void Rename(string name) => Name = name;

    public override string ToString() => $"{Name} ({Type}) - {Id}";
}
