using System.Runtime.Serialization;

namespace WSPizzariaPoloh
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int ProdutoId { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public decimal Preco { get; set; }
        [DataMember]
        public int Quantidade { get; set; }
    }
}
