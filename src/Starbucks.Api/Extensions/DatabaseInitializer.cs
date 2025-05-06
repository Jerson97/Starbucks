using Humanizer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Starbucks.Api.Resources;
using Starbucks.Domain;
using Starbucks.Persistence;

namespace Starbucks.Api.Extensions;

public static class DatabaseInitializer
{
    public static async Task ApplyMigration(this IApplicationBuilder builder, IWebHostEnvironment? environment)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<StarbucksDbContext>();
                await context.Database.MigrateAsync();
                await SeedData(context, environment);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error en la migracion");
                
            }
        }
    }


    private static async Task SeedData(StarbucksDbContext context, IWebHostEnvironment? environment)
    {
        if (context.Cafes.Any())
        {
            return;
        }

        if (environment is null)
        {
            throw new Exception("El enviroment no se cargo");
        }

        var rootPath = environment.ContentRootPath;
        var fullPathCafe = Path.Combine(rootPath, "Resources/cafe.json");
        var cafeDataText = await File.ReadAllTextAsync(fullPathCafe);
        var data = JsonConvert.DeserializeObject<List<CafeJson>>(cafeDataText) ?? Enumerable.Empty<CafeJson>();

        var ingredienteMaestro = new List<Ingrediente>();
        var cafeMaster = new List<Cafe>();
        var random = new Random();
        
        foreach (var cafeJson in data)
        {
            var ingredientesLocal = new List<Ingrediente>();

            foreach (var ing in cafeJson.Ingredientes)
            {
                var ingrediente = ingredienteMaestro.Where(s => string.Equals(s.Nombre,ing,StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();  

                if (ingrediente is null)
                {
                    ingrediente = new Ingrediente
                    {
                        Id = Guid.NewGuid(),
                        Nombre = ing
                    };


                    ingredienteMaestro.Add(ingrediente);
                }  

                ingredientesLocal.Add(ingrediente);
                
            }

            var cafe = new Cafe
            {
                Nombre = cafeJson.Titulo!,
                Descripcion = cafeJson.Descripcion,
                Imagen = cafeJson.Imagen,
                CategoriaId = cafeJson.Categoria,
                Precio = RandomPrecio(random, 2, 15),
                Ingredientes = ingredientesLocal
            };

            cafeMaster.Add(cafe);
        }

        await context.Ingredientes.AddRangeAsync(ingredienteMaestro);
        await context.Cafes.AddRangeAsync(cafeMaster);

        await context.SaveChangesAsync();

    }


    private static decimal RandomPrecio(Random random, double min, double max)
    {
        return Convert.ToDecimal(Math.Round( random.NextDouble() * Math.Abs(max-min) + min, 2 ));
    }
}


