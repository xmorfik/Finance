using Finance.Core.Entities;
using Finance.Repositories.Interfaces;
using Finance.Repositories.Specifications;
using Finance.Services.Exceptions;
using Finance.Services.Interfaces;

namespace Finance.Services;

public class ReportService : IReportService
{
    private readonly IRepository<Income> _incomesRepository;
    private readonly IRepository<Expense> _expensesRepository;

    public ReportService(IRepository<Income> incomesRepository, IRepository<Expense> expensesRepository)
    {
        _incomesRepository = incomesRepository;
        _expensesRepository = expensesRepository;
    }

    public async ValueTask<Report?> GetDailyReport(DateOnly date)
    {
        var incomes = await _incomesRepository.ListAsync(new IncomesDailyReportSpecification(date));
        var expenses = await _expensesRepository.ListAsync(new ExpensesDailyReportSpecification(date));

        if (incomes == null || expenses == null)
        {
            throw new NotFoundException();
        }

        return new Report(incomes, expenses);
    }

    public async ValueTask<Report?> GetPeriodReport(DateOnly start, DateOnly end)
    {
        var incomes = await _incomesRepository.ListAsync(new IncomePeriodReportSpecification(start, end));
        var expenses = await _expensesRepository.ListAsync(new ExpensePeriodReportSpecification(start, end));

        if (incomes == null || expenses == null)
        {
            throw new NotFoundException();
        }

        return new Report(incomes, expenses);
    }

    public async ValueTask<Report?> GetAllReport()
    {
        var incomes = await _incomesRepository.ListAsync();
        var expenses = await _expensesRepository.ListAsync();

        if (incomes == null || expenses == null)
        {
            throw new NotFoundException();
        }

        return new Report(incomes, expenses);
    }
}