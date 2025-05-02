namespace Starbucks.Domain;

public class Categoria
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public ICollection<Cafe> Cafes { get; set; } = [];
}
