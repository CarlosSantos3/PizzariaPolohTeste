using PizzariaPoloh.Dominio.Entidades;
using PizzariaPoloh.Dominio.Repositorio.Interfaces;

namespace PizzariaPoloh.Dominio.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly PizzariaPolohDBContext _context = new PizzariaPolohDBContext();
        
        /// <summary>
        /// Salva o pedido
        /// </summary>
        /// <param name="pedido">Número do pedido inserido</param>
        /// <returns></returns>
        public int SalvaPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return pedido.PedidoId;
        }
    }
}
