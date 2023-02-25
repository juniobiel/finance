using FinanceApp.Budget.API.Application.Commands;
using FinanceApp.Budget.API.Data;
using FinanceApp.Budget.API.Data.Repository;
using FinanceApp.Core.User;

namespace FinanceApp.Budget.API.Configuration
{
    public static class DependencyInjections
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) 
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<BudgetContext>();

            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();

            services.AddScoped<IExpenseCommandHandler, ExpenseCommandHandler>();
            services.AddScoped<IExpenseCommand, ExpenseCommand>();

            return services;
        }
    }
}
