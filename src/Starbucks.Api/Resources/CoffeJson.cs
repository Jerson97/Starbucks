namespace Starbucks.Api.Resources;

public class CafeJson
{
   public Guid CafeId {get;set;} = Guid.NewGuid();
   public string? Titulo { get; set; }
   public string? Descripcion { get; set; }
   public string? Imagen { get; set; }
   public int Categoria { get; set; }
   public string[] Ingredientes {get;set;} = [];

}
