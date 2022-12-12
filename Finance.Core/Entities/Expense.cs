using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Finance.Core.Entities;

public class Expense : BaseEntity
{
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    public int? ExpenseCategoryId { get; set; }
    [JsonIgnore]
    public ExpenseCategory? ExpenseCategory { get; set; }
}
