using FinanceApp.Core.Domain;

namespace FinanceApp.Budget.API.Models
{
    public class Expense : Entity, IAggregateRoot
    {

        public string Description { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal Value { get; private set; }
        public bool ItsPaid { get; private set; }
        public DateTime PaidDate { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid? UpdatedByUserId { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected Expense() { }

        public Expense(string description, DateTime paymentDate, decimal value, bool itsPaid, DateTime paidDate, Guid userId, DateTime createdAt)
        {
            Description = description;
            PaymentDate = paymentDate;
            Value = value;
            ItsPaid= itsPaid;
            PaidDate = paidDate;
            UserId = userId;
            CreatedAt = createdAt;
        }
    }
}
