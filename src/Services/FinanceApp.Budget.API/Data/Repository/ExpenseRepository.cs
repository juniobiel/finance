using FinanceApp.Budget.API.Models;
using FinanceApp.Core.Data;
using FinanceApp.Core.User;

namespace FinanceApp.Budget.API.Data.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly BudgetContext _context;

        public ExpenseRepository( BudgetContext context, 
            IAspNetUser user )
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose() => _context.Dispose();

        public void AddExpense( Expense expense)
        {
            _context.Expenses.Add(expense);
        }
    }
}
