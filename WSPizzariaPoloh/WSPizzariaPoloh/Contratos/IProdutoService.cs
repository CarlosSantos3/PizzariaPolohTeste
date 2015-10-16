using System.ServiceModel;

namespace WSPizzariaPoloh
{
    [ServiceContract]
    public interface IProdutoService
    {
        [OperationContract]
        Produto Buscar(string Nome);
        [OperationContract]
        void Adicionar(Produto prod);
    }
}
