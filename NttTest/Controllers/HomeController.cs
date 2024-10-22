using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NttTest.Extensions;
using NttTest.Models;
using NttTest.Services;
using NttTest.ViewModels;

namespace NttTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
    {
        _logger = logger;
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _productService.GetProductViewModelsAsync());
    }

    public async Task<IActionResult> DeleteProduct(int productId)
    {
        await _productService.DeleteAsync(productId);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> AddOrUpdateProduct([FromQuery] int? productId)
    {
        if (productId is not null)
        {
            var product = await _productService.GetProductAsync(productId.Value);
            return View((product?.ToProductViewModel() ?? new ProductViewModel(),
                new SelectList(await _categoryService.GetCategoryNamesAsync(), product?.Category?.Name)));
        }
        return View((new ProductViewModel(), new SelectList(await _categoryService.GetCategoryNamesAsync() )));
    }

    [HttpPost("{controller}/product")]
    public async Task<IActionResult> AddOrUpdateProductPost([FromForm] ProductViewModel productViewModel)
    {
        productViewModel.Id = int.Parse(HttpContext.Request.Cookies["productId"]);
        var product = await _productService.GetProductAsync(productViewModel.Id);
        if (product is not null)
        {
            product.Title = productViewModel.Title;
            product.Description = productViewModel.Description;
            product.Price = productViewModel.Price;
            product.Quantity = productViewModel.Quantity;
            product.CategoryId = (await _categoryService.GetCategoryAsync(x => x.Name == productViewModel.Category)).Id;
            await _productService.AddOrUpdateAsync(product);
        }
        else
        {
            await _productService.AddOrUpdateAsync(new Product()
            {
                Title = productViewModel.Title,
                Description = productViewModel.Description,
                Price = productViewModel.Price,
                Quantity = productViewModel.Quantity,
                CategoryId = (await _categoryService.GetCategoryAsync(x => x.Name == productViewModel.Category)).Id 
            });
        }

        return RedirectToAction("Index");
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}