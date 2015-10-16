namespace PizzariaPoloh.Dominio.Entidades
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public int Quantidade { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
    }
}
