namespace NttTest.ViewModels;

public class ProductViewModel
{
    public int Id { get; init; } 
    public string Title { get; init; } 
    public string? Description { get; init; } 
    public decimal Price { get; init; }
    public int Quantity { get; init; } 
    public string Category { get; init; }

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