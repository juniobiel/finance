using AutoMapper;
using FinanceApp.Budget.API.Models;
using FinanceApp.Budget.API.ViewModels;

namespace FinanceApp.Budget.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ExpenseViewModel, Expense>().ReverseMap();
        }
    }
}
