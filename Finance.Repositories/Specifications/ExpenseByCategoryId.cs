using Ardalis.Specification;
using Finance.Core.Entities;

namespace Finance.Repositories.Specifications;

public class ExpenseByCategoryId : Specification<Expense>
{
    public ExpenseByCategoryId(int id)
    {
        Query.Where(e => e.ExpenseCategoryId == id);
    }
}