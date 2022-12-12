using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Finance.Core.Entities;

public class Income : BaseEntity
{
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    public int? IncomeCategoryId { get; set; }
    [JsonIgnore]
    public IncomeCategory? IncomeCategory { get; set; }
}
