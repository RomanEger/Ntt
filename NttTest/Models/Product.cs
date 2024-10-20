using System.ComponentModel.DataAnnotations;

namespace NttTest.Models;

public class Product: EntityBase
{
    [MaxLength(150)]
    public string Title { get; set; }
    
    public string Description { get; set; }

    private decimal _price;
    /// <exception cref="ArgumentException"></exception>
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price must be greater than 0.");
            }
            _price = value;
        }
    }
    
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}