using Ardalis.Specification;
using Finance.Core.Entities;

namespace Finance.Repositories.Specifications;

public class IncomesDailyReportSpecification : Specification<Income>
{
    public IncomesDailyReportSpecification(DateOnly date)
    {
        var dateTime = date.ToDateTime(TimeOnly.MinValue);
        Query.Where(i => i.DateTime.Date == dateTime);
    }
}