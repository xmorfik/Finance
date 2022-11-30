using Ardalis.Specification;
using Finance.Core.Entities;

namespace Finance.Repositories.Specifications;

public class ExpensesDailyReportSpecification : Specification<Expense>
{
    public ExpensesDailyReportSpecification(DateOnly date)
    {
        var dateTime = date.ToDateTime(TimeOnly.MinValue);
        Query.Where(e => e.DateTime.Date == dateTime);
    }
}