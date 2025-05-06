namespace Starbucks.Domain;

public class Ingrediente : BaseEntity
{
    public required string Nombre { get; set; }
    public ICollection<Cafe> Cafes { get; set; } = [];
    public ICollection<CafeIngrediente> CafeIngredientes { get; set; } = [];
}
