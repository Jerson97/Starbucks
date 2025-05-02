namespace Starbucks.Domain;

public class CafeIngrediente
{
    public Guid IngredienteId { get; set; }
    public Guid CafeId { get; set; }
    public Ingrediente? Ingrediente { get; set; }
    public Cafe? Cafe{ get; set; }
}
