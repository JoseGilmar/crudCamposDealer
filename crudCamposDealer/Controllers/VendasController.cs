using crudCamposDealer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace crudCamposDealer.Controllers
{
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_context.Clientes, "IdCliente", "Nome");
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "IdProduto", "Descricao");
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,ProdutoId,Quantidade,DataVenda,ValorUnitario,ValorTotal")] Venda venda)
        {

            _context.Add(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Vendas/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            ViewBag.ClienteId = new SelectList(_context.Clientes, "IdCliente", "Nome", venda.ClienteId);
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "IdProduto", "Descricao", venda.ProdutoId);

            return View(venda);
        }

        // POST: Vendas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,ClienteId,ProdutoId,Quantidade,DataVenda,ValorUnitario,ValorTotal")] Venda venda)
        {
            var existingVenda = await _context.Venda.FindAsync(id);
            if (existingVenda != null)
            {
                existingVenda.ClienteId = venda.ClienteId;
                existingVenda.ProdutoId = venda.ProdutoId;
                existingVenda.Quantidade = venda.Quantidade;
                existingVenda.DataVenda = venda.DataVenda;
                existingVenda.ValorUnitario = venda.ValorUnitario;

                _context.Update(existingVenda);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Clientes/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(v => v.IdVenda == id);
        }

        // GET: Vendas/GetProdutoValorUnitario
        public async Task<IActionResult> GetProdutoValorUnitario(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Json(new { valorUnitario = produto.ValorUnitario.ToString("N2") });
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var vendas = _context.Venda.Include(v => v.Cliente).Include(v => v.Produto);
            return View(await vendas.ToListAsync());
        }
    }
}