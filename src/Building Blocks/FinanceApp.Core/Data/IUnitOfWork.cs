namespace FinanceApp.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
