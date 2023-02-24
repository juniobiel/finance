using FinanceApp.Budget.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Budget.API.Data
{
    public class BudgetContext : DbContext
    {
        DbSet<Expense> Expenses { get; set; }
        DbSet<Income> Incomes { get; set; }

        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }


        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetContext).Assembly);
        }
    }
}
