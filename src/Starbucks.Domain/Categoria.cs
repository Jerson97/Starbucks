using System.Diagnostics.CodeAnalysis;

namespace Starbucks.Domain;

public class Categoria
{
    [SetsRequiredMembers]
    private Categoria(int id, string nombre) => (Id, Nombre) = (id,nombre);
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public ICollection<Cafe> Cafes { get; set; } = [];
    public static Categoria Crear(int id)
    {
        var categoryName = (CategoriaEnum)id;
        var categoryNameString = categoryName.ToString();

        return new Categoria(id, categoryNameString);
    }
}
