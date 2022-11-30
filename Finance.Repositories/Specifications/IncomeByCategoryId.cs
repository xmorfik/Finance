using Ardalis.Specification;
using Finance.Core.Entities;

namespace Finance.Repositories.Specifications;

public class IncomeByCategoryId : Specification<Income>
{
    public IncomeByCategoryId(int id)
    {
        Query.Where(i => i.IncomeCategoryId == id);
    }
}
