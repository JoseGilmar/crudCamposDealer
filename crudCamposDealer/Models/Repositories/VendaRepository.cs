using Microsoft.EntityFrameworkCore;

namespace crudCamposDealer.Models.Repositories;

public class VendaRepository
{
    private readonly DbSet<Venda> _repository;
    private readonly Contexto _context;

    public VendaRepository(Contexto context)
    {
        _repository = context.Set<Venda>();
        _context = context;
    }

    public IEnumerable<Venda> GetAllSales()
    {
        return _repository
            .Include(x => x.Cliente)
            .Include(x => x.Produto)
            .ToList();
    }
}
