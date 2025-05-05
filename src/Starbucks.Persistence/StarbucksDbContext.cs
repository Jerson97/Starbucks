using Microsoft.EntityFrameworkCore;
using Starbucks.Domain;

namespace Starbucks.Persistence;

public class StarbucksDbContext(DbContextOptions options) :DbContext(options)
{
    public required DbSet<Categoria> Categorias{ get; set; }
    public required DbSet<Cafe> Cafes{ get; set; }
    public required DbSet<Ingrediente> Ingredientes{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>()
        .HasMany(c => c.Cafes)
        .WithOne(ca => ca.Categoria)
        .HasForeignKey(ca => ca.CategoriaId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Cafe>()
        .Property(ca => ca.Precio)
        .HasPrecision(10, 2);

        modelBuilder.Entity<Cafe>()
        .HasMany(ing => ing.Ingredientes)
        .WithMany(ing => ing.Cafes)
        .UsingEntity<CafeIngrediente>(
            j => j
                .HasOne(p => p.Ingrediente)
                .WithMany(p => p.CafeIngredientes)
                .HasForeignKey(p => p.IngredienteId),
            j => j
                .HasOne(p => p.Cafe)
                .WithMany(p => p.CafeIngredientes)
                .HasForeignKey(p => p.CafeId),
            j => 
            {
                j.HasKey(t => new { t.CafeId, t.IngredienteId });
            }
        );

        modelBuilder.Entity<Categoria>().HasData(GetCategorias());
    }

    private IEnumerable<Categoria> GetCategorias()
    {
        return Enum.GetValues<CategoriaEnum>().Select(p => Categoria.Crear((int)p));
    }

}
