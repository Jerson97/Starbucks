namespace Starbucks.Domain;

public class Cafe : BaseEntity
{
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public string? Imagen { get; set; }
    public Categoria? Categoria { get; set; }
    public ICollection<Ingrediente> Ingredientes { get; set;} = [];
    public ICollection<CafeIngrediente> CafeIngredientes { get; set;} = [];
}
