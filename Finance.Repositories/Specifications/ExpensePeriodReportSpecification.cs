using Ardalis.Specification;
using Finance.Core.Entities;

namespace Finance.Repositories.Specifications;

public class ExpensePeriodReportSpecification : Specification<Expense>
{
    public ExpensePeriodReportSpecification(DateOnly start, DateOnly end)
    {
        var startDateTime = start.ToDateTime(TimeOnly.MinValue);
        var endDateTime = end.ToDateTime(TimeOnly.MinValue);

        Query.Where(
            e => e.DateTime.Date.CompareTo(startDateTime) >= 0
            && e.DateTime.Date.CompareTo(endDateTime) <= 0);
    }
}