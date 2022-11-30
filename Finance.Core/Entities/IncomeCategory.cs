using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Finance.Core.Entities;

public class IncomeCategory : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [JsonIgnore]
    public ICollection<Income>? Incomes { get; set; }
}