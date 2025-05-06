using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starbucks.Domain;
using Starbucks.Persistence;

namespace Starbucks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly StarbucksDbContext _context;

    public CategoriaController(StarbucksDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Categoria>> Get()
    {
        return await _context.Categorias.ToListAsync();
    }
}
