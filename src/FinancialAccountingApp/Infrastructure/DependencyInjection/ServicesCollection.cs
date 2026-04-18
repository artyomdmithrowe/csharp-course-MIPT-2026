using FinancialAccountingApp.Infrastructure.Repositories;
using FinancialAccountingApp.Interfaces;
using FinancialAccountingApp.Services.Facades;
using FinancialAccountingApp.Services.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialAccountingApp.Infrastructure.DependencyInjection;

public static class ServicesCollection
{
    public static IServiceCollection AddFinancialAccountingApp(this IServiceCollection services)
    {
        services.AddSingleton<IBankAccountRepository, BankAccountRepository>();
        services.AddSingleton<ICategoryRepository, CategoryRepository>();
        services.AddSingleton<IOperationRepository, OperationRepository>();

        services.AddSingleton<BankAccountFactory>();
        services.AddSingleton<CategoryFactory>();
        services.AddSingleton<OperationFactory>();

        services.AddSingleton<BankAccountFacade>();
        services.AddSingleton<CategoryFacade>();
        services.AddSingleton<OperationFacade>();

        return services;
    }
}
