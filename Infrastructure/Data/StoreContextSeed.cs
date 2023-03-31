using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.ProductBrands.Any())
        {
            // we are reading in API
            var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
            
            // deserialize into C# object
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            
            // still working with memory, we need to save changes in db
            context.ProductBrands.AddRange(brands);
        }
        
        if (!context.ProductTypes.Any())
        {
            // we are reading in API
            var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
            
            // deserialize into C# object
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            
            // still working with memory, we need to save changes in db
            context.ProductTypes.AddRange(types);
        }
        
        
        if (!context.Products.Any())
        {
            // we are reading in API
            var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
            
            // deserialize into C# object
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            
            // still working with memory, we need to save changes in db
            context.Products.AddRange(products);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
}