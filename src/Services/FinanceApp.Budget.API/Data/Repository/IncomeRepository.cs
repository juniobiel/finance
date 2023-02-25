using FinanceApp.Budget.API.Models;
using FinanceApp.Core.Data;
using FinanceApp.Core.User;

namespace FinanceApp.Budget.API.Data.Repository
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly BudgetContext _context;
        private readonly IAspNetUser _user;

        public IncomeRepository( BudgetContext context, 
            IAspNetUser user )
        {
            _context = context;
            _user = user;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AddIncome( Income income )
        {
            income.UserId = _user.ObterUserId();
            income.CreatedAt = DateTime.Now;
            _context.Incomes.Add( income );
        }

        public void Dispose() => _context.Dispose();
    }
}
