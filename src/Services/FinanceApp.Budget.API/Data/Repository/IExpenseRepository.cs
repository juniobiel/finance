using FinanceApp.Budget.API.Models;
using FinanceApp.Core.Data;

namespace FinanceApp.Budget.API.Data.Repository
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        void AddExpense(Expense expense);
    }
}
