using NttTest.Models;
using NttTest.ViewModels;

namespace NttTest.Extensions;

public static class MyExtensions
{
    public static ProductViewModel ToProductViewModel(this Product product)
    {
        return new ProductViewModel(
            product.Id,
            product.Title,
            product.Description,
            product.Price,
            product.Quantity,
            product.Category.Name
        );
    }
}