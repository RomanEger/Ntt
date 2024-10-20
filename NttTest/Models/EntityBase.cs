using System.ComponentModel.DataAnnotations;

namespace NttTest.Models;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}