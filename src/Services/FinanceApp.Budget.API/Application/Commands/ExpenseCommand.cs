using FinanceApp.Budget.API.Data.Repository;
using FinanceApp.Budget.API.Models;
using FinanceApp.Core.Commands;

namespace FinanceApp.Budget.API.Application.Commands
{
    public interface IExpenseCommand
    {
        Task<bool> CreateExpense( Expense expense );
    }

    public class ExpenseCommand : Command, IExpenseCommand
    {

        private readonly IExpenseRepository _repository;

        public ExpenseCommand( IExpenseRepository repository )
        {
            _repository = repository;
        }

        public async Task<bool> CreateExpense( Expense expense )
        {
            _repository.AddExpense(expense);
            return await SaveData(_repository.UnitOfWork);
        }
    }
}
