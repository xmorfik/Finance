using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Finance.Core.Entities;

public class ExpenseCategory : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [JsonIgnore]
    public ICollection<Expense>? Expenses { get; set; }
}