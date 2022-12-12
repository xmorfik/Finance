using Finance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infrastructure.Data.Configurations;

public class ExpenseCongiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasOne(e => e.ExpenseCategory).WithMany(c => c.Expenses).OnDelete(DeleteBehavior.Restrict);
    }
}