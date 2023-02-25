using AutoMapper;
using FinanceApp.Budget.API.Application.Commands;
using FinanceApp.Budget.API.Models;
using FinanceApp.Budget.API.ViewModels;
using FinanceApp.Services.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Budget.API.Controllers
{
    [Authorize]
    [Route("expenses")]
    public class ExpensesController : MainController
    {
        private readonly IExpenseCommandHandler _expenseCommandHandler;
        private readonly IMapper _mapper;

        public ExpensesController( IExpenseCommandHandler expenseCommandHandler, 
            IMapper mapper )
        {
            _expenseCommandHandler = expenseCommandHandler;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ActionResult> NewExpense(ExpenseViewModel expense)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _expenseCommandHandler.CreateExpenseHandle(expense);

            if(!result)
                return CustomResponse(BadRequest("Não foi possível concluir a operação"));

            return CustomResponse(Ok("Registro efetuado com sucesso!"));
        }
    }
}
