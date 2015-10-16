using PizzariaPoloh.Dominio.Entidades;

namespace PizzariaPoloh.Dominio.Repositorio.Interfaces
{
    public interface IPedidoRepositorio
    {
        int SalvaPedido(Pedido pedido);
    }
}
