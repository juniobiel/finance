using FinanceApp.Budget.API.Models;
using FinanceApp.Core.Data;

namespace FinanceApp.Budget.API.Data.Repository
{
    public interface IIncomeRepository : IRepository<Income>
    {
        void AddIncome( Income income );
    }
}
