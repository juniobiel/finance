using FinanceApp.Core.Data;

namespace FinanceApp.Core.Commands
{
    public abstract class Command
    {
        public DateTime Timestamp { get; private set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        protected async Task<bool> SaveData(IUnitOfWork uow)
        {
            if(!await uow.Commit()) return false;

            return true;
        }
    }
}
