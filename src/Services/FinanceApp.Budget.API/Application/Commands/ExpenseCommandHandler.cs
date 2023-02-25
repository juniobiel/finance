using FinanceApp.Budget.API.Models;
using FinanceApp.Budget.API.ViewModels;
using FinanceApp.Core.Commands;
using FinanceApp.Core.User;

namespace FinanceApp.Budget.API.Application.Commands
{
    public interface IExpenseCommandHandler : ICommandHandler<ExpenseCommand>
    {
        Task<bool> CreateExpenseHandle( ExpenseViewModel expenseViewModel );
    }

    public class ExpenseCommandHandler : IExpenseCommandHandler
    {
        private readonly IExpenseCommand _command;
        private readonly IAspNetUser _user;

        public ExpenseCommandHandler( IExpenseCommand command, IAspNetUser user )
        {
            _command = command;
            _user = user;
        }

        public async Task<bool> CreateExpenseHandle( ExpenseViewModel expenseViewModel )
        {
            var expense = new Expense(expenseViewModel.Description,
                expenseViewModel.PaymentDate,
                expenseViewModel.Value,
                expenseViewModel.ItsPaid,
                expenseViewModel.PaidDate,
                _user.ObterUserId(),
                DateTime.Now);

            return await _command.CreateExpense(expense);
        }
    }
}
