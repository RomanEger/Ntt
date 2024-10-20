using System.ComponentModel.DataAnnotations;

namespace NttTest.Models;

public class Category : EntityBase
{
    [MaxLength(150)]
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; }
}