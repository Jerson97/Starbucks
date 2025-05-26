using Core.mediatOR.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starbucks.Domain;
using Starbucks.Persistence;
using static Starbucks.Application.Categories.Queries.CategoriaListGet;

namespace Starbucks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<List<Categoria>> Get(CancellationToken cancellationToken)
    {
        var query = new Query();
        var resultado = await _mediator.Send(query, cancellationToken);
        return resultado;
    }
}
