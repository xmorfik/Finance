using Ardalis.Specification;
using Finance.Core.Entities;

namespace Finance.Repositories.Specifications;

public class IncomePeriodReportSpecification : Specification<Income>
{
    public IncomePeriodReportSpecification(DateOnly start, DateOnly end)
    {
        var startDateTime = start.ToDateTime(TimeOnly.MinValue);
        var endDateTime = end.ToDateTime(TimeOnly.MinValue);

        Query.Where(
            i => i.DateTime.Date.CompareTo(startDateTime) >= 0 
            && i.DateTime.Date.CompareTo(endDateTime) <= 0);
    }
}