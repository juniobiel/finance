using FinanceApp.Budget.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.Budget.API.Data.Mappings
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure( EntityTypeBuilder<Expense> builder )
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Value)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.ToTable("Expenses");
        }
    }

    public class IncomeMapping : IEntityTypeConfiguration<Income>
    {
        public void Configure( EntityTypeBuilder<Income> builder )
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Value)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.ToTable("Incomes");
        }
    }
}
