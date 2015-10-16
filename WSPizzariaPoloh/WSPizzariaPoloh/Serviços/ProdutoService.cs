namespace WSPizzariaPoloh.Serviços
{
    public class ProdutoService : IProdutoService
    {
        public void Adicionar(Produto prod)
        {
            ProdutoDB prodDb = new ProdutoDB();
            prodDb.Adicionar(prod);
        }

        public Produto Buscar(string Nome)
        {
            ProdutoDB prodDb = new ProdutoDB();
            return prodDb.Buscar(Nome);
        }
    }
}
