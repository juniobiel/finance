using FinanceApp.Core.Domain;

namespace FinanceApp.Budget.API.Models
{
    public class Income : Entity, IAggregateRoot
    {
        public string Description { get; private set; }
        public DateTime ReceivedDate { get; private set; }
        public decimal Value { get; private set; }
        public bool Received { get; private set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedByUserId { get; set; }
        public DateTime UpdatedAt { get; set; }

        protected Income() { }
    }
}
