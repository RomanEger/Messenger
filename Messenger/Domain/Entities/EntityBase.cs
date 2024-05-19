using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class EntityBase
{
    [Key]
    public Guid Id { get; protected set; }
}