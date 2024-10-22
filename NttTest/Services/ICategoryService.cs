using System.Linq.Expressions;
using NttTest.Models;

namespace NttTest.Services;

public interface ICategoryService
{
    Task<List<string>> GetCategoryNamesAsync();
    Task<Category?> GetCategoryAsync(Expression<Func<Category, bool>> func);
}