namespace Finance.Core.Entities;

public class Report
{
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }

    private ICollection<Income> _incomes;
    private ICollection<Expense> _expenses;

    public Report(ICollection<Income> incomes, ICollection<Expense> expenses)
    {
        Incomes = incomes;
        Expenses = expenses;
    }

    public ICollection<Income> Incomes
    {
        get => _incomes;
        set
        {
            _incomes = value;
            TotalIncome = CalculateTotalIncome(_incomes);
        }
    }

    public ICollection<Expense> Expenses
    {
        get => _expenses;
        set
        {
            _expenses = value;
            TotalExpense = CalculateTotalExpense(_expenses);
        }
    }

    private decimal CalculateTotalIncome(ICollection<Income> incomes)
    {
        decimal total = 0;
        foreach (var income in incomes)
        {
            total += income.Amount;
        }
        return total;
    }

    private decimal CalculateTotalExpense(ICollection<Expense> expenses)
    {
        decimal total = 0;
        foreach (var income in expenses)
        {
            total += income.Amount;
        }
        return total;
    }
}