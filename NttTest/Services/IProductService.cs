using NttTest.Models;
using NttTest.ViewModels;

namespace NttTest.Services;

public interface IProductService
{
    Task<List<ProductViewModel>> GetProductViewModelsAsync();
    Task<Product?> GetProductAsync(int productId);
    Task AddOrUpdateAsync(Product product);
    Task DeleteAsync(int productId);
}