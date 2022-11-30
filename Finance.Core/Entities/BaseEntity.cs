using Finance.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Finance.Core.Entities;

public class BaseEntity : IAggregateRoot
{
    [Key]
    public int? Id { get; set; }
}