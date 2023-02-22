namespace FinanceApp.Core.Commands
{
    public abstract class Command
    {
        public DateTime Timestamp { get; private set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
