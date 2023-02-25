namespace FinanceApp.Budget.API.ViewModels
{
    public class IncomeViewModel
    {
        public string Description { get; private set; }
        public DateTime ReceivedDate { get; private set; }
        public decimal Value { get; private set; }
        public bool Received { get; private set; }
    }
}
