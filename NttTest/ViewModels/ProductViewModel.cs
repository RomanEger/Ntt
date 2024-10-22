namespace NttTest.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; } 
    public string Title { get; set; } 
    public string? Description { get; set; } 
    public decimal Price { get; set; }
    public int Quantity { get; set; } 
    public string Category { get; set; }

    public ProductViewModel()
    {
        
    }

    public ProductViewModel(int id, string title, string? description, decimal price, int quantity, string category)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Quantity = quantity;
        Category = category;
    }
}