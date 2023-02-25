using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Budget.API.ViewModels
{
    public class ExpenseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public bool ItsPaid { get; set; }
        [Required]
        public DateTime PaidDate { get; set; }
    }
}
