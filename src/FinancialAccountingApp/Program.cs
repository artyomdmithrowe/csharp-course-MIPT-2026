using FinancialAccountingApp.Infrastructure.DependencyInjection;
using FinancialAccountingApp.Models.Enums;
using FinancialAccountingApp.Services.Facades;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialAccountingApp;

public static class Program
{
    public static void Main()
    {
        var services = new ServiceCollection();
        services.AddFinancialAccountingApp();

        var serviceProvider = services.BuildServiceProvider();

        var bankAccountFacade = serviceProvider.GetRequiredService<BankAccountFacade>();
        var categoryFacade = serviceProvider.GetRequiredService<CategoryFacade>();
        var operationFacade = serviceProvider.GetRequiredService<OperationFacade>();

        Console.WriteLine("Financial Accounting Demo");
        Console.WriteLine();

        var mainAccount = bankAccountFacade.Create("Main Account", 0m);

        var salaryCategory = categoryFacade.Create(CategoryType.Income, "Salary");
        var cafeCategory = categoryFacade.Create(CategoryType.Expense, "Cafe");
        var transportCategory = categoryFacade.Create(CategoryType.Expense, "Transport");

        operationFacade.Create(
            OperationType.Income,
            mainAccount.Id,
            salaryCategory.Id,
            100000m,
            new DateTime(2026, 4, 18),
            "Salary"
        );

        operationFacade.Create(
            OperationType.Expense,
            mainAccount.Id,
            cafeCategory.Id,
            1250m,
            new DateTime(2026, 4, 18),
            "Dinner"
        );

        operationFacade.Create(
            OperationType.Expense,
            mainAccount.Id,
            transportCategory.Id,
            620m,
            new DateTime(2026, 4, 19),
            "Metro"
        );

        Console.WriteLine("Accounts:");
        foreach (var bankAccount in bankAccountFacade.GetAll())
        {
            Console.WriteLine(bankAccount);
        }

        Console.WriteLine();
        Console.WriteLine("Categories:");
        foreach (var category in categoryFacade.GetAll())
        {
            Console.WriteLine(category);
        }

        Console.WriteLine();
        Console.WriteLine("Operations:");
        foreach (var operation in operationFacade.GetAll())
        {
            Console.WriteLine(operation);
        }

        Console.WriteLine();
        Console.WriteLine("Operations for main account:");
        foreach (var operation in operationFacade.GetByBankAccountId(mainAccount.Id))
        {
            Console.WriteLine(operation);
        }
    }
}
