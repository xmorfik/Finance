using Finance.Core.Entities;

namespace Finance.Services.Interfaces;

public interface IReportService
{
    public ValueTask<Report?> GetDailyReport(DateOnly date);
    public ValueTask<Report?> GetPeriodReport(DateOnly dateStart, DateOnly dateEnd);
}