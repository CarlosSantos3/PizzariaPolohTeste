using PizzariaPoloh.Dominio.Entidades;
using PizzariaPoloh.Dominio.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PizzariaPoloh.Dominio.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly PizzariaPolohDBContext _context = new PizzariaPolohDBContext();

        public IEnumerable<Produto> PegaProdutos(IEnumerable<int> ids = null)
        {
            if (ids == null)
                return _context.Produtos;

            return _context.Produtos.Where(t => ids.Contains(t.ProdutoId));
        }
    }
}
