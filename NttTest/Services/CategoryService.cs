using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NttTest.Models;

namespace NttTest.Services;

public class CategoryService : ICategoryService
{
    private readonly NttDbContext _dbContext;

    public CategoryService(NttDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<string>> GetCategoryNamesAsync()
    {
        return _dbContext.Categories.Select(x => x.Name).ToListAsync();
    }

    public Task<Category?> GetCategoryAsync(Expression<Func<Category, bool>> func)
    {
        return _dbContext.Categories.FirstOrDefaultAsync(func);
    }
}