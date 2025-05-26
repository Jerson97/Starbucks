using Core.mediatOR.Contracts;
using Microsoft.EntityFrameworkCore;
using Starbucks.Domain;
using Starbucks.Persistence;

namespace Starbucks.Application.Categories.Queries;

public class CategoriaListGet
{
    public class Query : IRequest<List<Categoria>>
    {}

    public class Handler(StarbucksDbContext context) : IRequestHandler<Query, List<Categoria>>
    {
        private readonly StarbucksDbContext _context = context;
        public async Task<List<Categoria>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
