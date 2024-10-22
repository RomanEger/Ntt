using Microsoft.EntityFrameworkCore;
using NttTest.Extensions;
using NttTest.Models;
using NttTest.ViewModels;

namespace NttTest.Services;

public class ProductService : IProductService
{
    private readonly NttDbContext _dbContext;

    public ProductService(NttDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<ProductViewModel>> GetProductViewModelsAsync()
    {
        var products =  await _dbContext.Products
            .Include(x => x.Category)
            .ToListAsync();
        var productViewModels = new List<ProductViewModel>();
        products.ForEach(x => productViewModels.Add(x.ToProductViewModel()));
        return productViewModels;
    }

    public async Task<ProductViewModel?> GetProductViewModelAsync(int productId)
    {
        var product = await GetProductAsync(productId);
        return product?.ToProductViewModel();
    }

    public async Task<Product?> GetProductAsync(int productId)
    {
        var p = await _dbContext.Products.Include(x => x.Category).FirstOrDefaultAsync();
        return await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == productId);
    }

    public async Task AddOrUpdateAsync(Product product)
    {
        if (await GetProductViewModelAsync(product.Id) is not null)
        {
            _dbContext.Products.Update(product);
        }
        else
        {
            await _dbContext.Products.AddAsync(product);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int productId)
    {
        var product = await GetProductAsync(productId);
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}